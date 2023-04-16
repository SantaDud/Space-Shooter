using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] protected int health;

    [SerializeField] protected GameObject healthBar;
    protected GameObject m_healthBar;
    protected Image healthBarFill;
    [SerializeField] protected float healthBarOffset;

    [SerializeField] protected GameObject destructionEffect;

    protected void Start()
    {
        if (gameObject.CompareTag("Player"))
            healthBar = UIManager.Instance.playerHealthBar;

        else
            healthBar = UIManager.Instance.enemyHealthBar;

        m_healthBar = Instantiate(healthBar, healthBar.transform.parent);
        healthBarFill = m_healthBar.transform.GetChild(0).GetComponent<Image>();
        healthBarFill.fillAmount = 1;
    }

    protected void Update()
    {
        Vector3 posOffset = new Vector3(0, healthBarOffset, 0);
        m_healthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + posOffset);
    }

    public void ReduceHealth(int damage)
    {
        if (health - damage > 0)
            SetHealth(health - damage);

        else
            DestroySpaceShip();
    }

    protected virtual void SetHealth(int health)
    {
        this.health = health;
    }

    protected virtual void DestroySpaceShip()
    {
        Destroy(m_healthBar);
        Destroy(gameObject);
        Destroy(Instantiate(destructionEffect, transform.position, transform.rotation), .5f);
    }
}