public class Boss : SpaceShip
{
    protected override void Start()
    {
        GameManager.cleanUp += CleanUp;
        base.Start();
    }

    protected override void DestroySpaceShip()
    {
        GameManager.cleanUp -= CleanUp;

        base.DestroySpaceShip();
        GameManager.Instance.score += 100;
        UIManager.Instance.UpdateScore();
    }

    void CleanUp() => base.DestroySpaceShip();
}
