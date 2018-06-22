public class Tower : TDObject
{
    private void Start()
    {
        myTransform = transform;
        health = maxHealth;
        forStart();
    }
}
