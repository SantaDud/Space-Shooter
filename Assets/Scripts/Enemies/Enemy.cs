public class Enemy : SpaceShip
{
    protected override void Start()
    {
        GameManager.cleanUp += CleanUp;
        base.Start();
    }

    protected override void DestroySpaceShip()
    {
        GameManager.cleanUp -= CleanUp;
        
        if (GameManager.Instance.IsTrue(2f, 1.9f))
            Powerups.Instance.SpawnPowerup(transform.position);
        
        base.DestroySpaceShip();
        GameManager.Instance.score++;
        UIManager.Instance.UpdateScore();
        FindObjectOfType<Level>().UpdateKills();
    }

    void CleanUp() => base.DestroySpaceShip();
}
