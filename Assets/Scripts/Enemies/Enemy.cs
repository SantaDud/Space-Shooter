public class Enemy : SpaceShip
{
    protected override void DestroySpaceShip()
    {
        base.DestroySpaceShip();
        GameManager.Instance.score++;
        UIManager.Instance.UpdateScore();
        EnemySpawner.Instance.Spawn();
        MeteorSpawner.Instance.Spawn();
    }

    protected override void SetHealth(int health)
    {
        base.SetHealth(health);
        healthBarFill.fillAmount = health / 100.0f;
    }
}
