public class HeroTank : Hero
{
    private void Start()
    {
        myTransform = transform;
        forStart();
    }

    private void Update()
    {
        forUpdate();
    }
}
