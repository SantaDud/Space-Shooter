using UnityEngine;

public class Player : SpaceShip
{
    public Vector3 Position
    {
        get
        {
            return transform.position;
        }

        set
        {
            transform.position = value;
        }
    }

    protected override void SetHealth(int health)
    {
        base.SetHealth(health);
        healthBarFill.fillAmount = health / 200.0f;
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
        base.DestroySpaceShip();
    }
}
