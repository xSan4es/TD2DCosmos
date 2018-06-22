public class HeroDD : Hero
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