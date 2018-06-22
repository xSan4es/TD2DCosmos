public class Arrow : MovingObject
{
    private void Start()
    {
        myTransform = transform;
    }

    private void Update()
    {
        //if (target.myRefScript.health <= 0) death();

        distance = distanceBetweenPoints(myTransform, target.myTransform);

        if (distance <= rangeOfAttack)
        {
            setDamage();
            death();
        }
        else
        {
            moveToTarget();
        }
    }
    
    public override void takeDamage(float forceOfAttack, TypeOfAttack typeOfAttack)
    {
        this.forceOfAttack = forceOfAttack;
        this.typeOfAttack = typeOfAttack;
    }
}
