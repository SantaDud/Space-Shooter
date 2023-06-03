using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] protected int originalHealth;
    protected int currentHealth;

    [SerializeField] protected GameObject destructionEffect;

    protected bool isAlreadyHit = false;

    protected virtual void Start() => currentHealth = originalHealth;

    public void ReduceHealth(int damage)
    {
        if (currentHealth - damage > 0)
            SetHealth(currentHealth - damage);

        else
            DestroySpaceShip();
    }

    protected virtual void SetHealth(int health) => currentHealth = health;

    protected virtual void DestroySpaceShip()
    {
        Destroy(gameObject);
        Destroy(Instantiate(destructionEffect, transform.position, transform.rotation), .5f);
    }
}