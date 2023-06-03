using UnityEngine;
using UnityEngine.UI;

public class Player : SpaceShip
{
    [SerializeField] protected GameObject healthBar;
    protected GameObject m_healthBar;
    protected Image healthBarFill;
    [SerializeField] protected float healthBarOffset;

    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    protected override void Start()
    {
        if (gameObject.CompareTag("Player"))
            healthBar = UIManager.Instance.playerHealthBar;

        m_healthBar = Instantiate(healthBar, healthBar.transform.parent);
        healthBarFill = m_healthBar.transform.GetChild(0).GetComponent<Image>();
        healthBarFill.fillAmount = 1;
        
        base.Start();
    }

    protected void Update()
    {
        Vector3 posOffset = new Vector3(0, healthBarOffset, 0);
        m_healthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position - posOffset);
    }

    protected override void SetHealth(int health)
    {
        base.SetHealth(health);
        healthBarFill.fillAmount = currentHealth / (float)originalHealth;
    }

    protected override void DestroySpaceShip()
    {
        try
        {
            EnemySpawner.Instance.spawnAnother = false; // Disable so no more enemies spawn
            FindObjectOfType<Enemy>().ReduceHealth(100);
        } 
        
        catch (System.Exception e) { Debug.Log($"Exception is {e.Message}"); }
        
        GameManager.Instance.GameOver();
        
        Destroy(m_healthBar);
        base.DestroySpaceShip();
    }
}
