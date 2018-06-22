using UnityEngine;

public class MovingObject : TDObject
{
    public TypeOfAttack typeOfAttack;
    public float speed;
    [HideInInspector]
    public float distance;
    public float forceOfAttack;
    public float rangeOfAttack;
    public int spriteAngle;

    public virtual float distanceBetweenPoints(Transform point1, Transform point2)
    {
        return (((point2.position.x - point1.position.x) * (point2.position.x - point1.position.x)) + ((point2.position.y - point1.position.y) * (point2.position.y - point1.position.y))) / 10;
    }

    public virtual void moveToTarget()
    {
        Vector2 delta = target.myTransform.position - myTransform.position;
        delta.Normalize();
        myTransform.position = new Vector3(myTransform.position.x + (delta.x * speed * Time.deltaTime), myTransform.position.y + (delta.y * speed * Time.deltaTime), myTransform.position.z);
        rotationToTarget(spriteAngle, target.myTransform.position); // поворот ворога в напрямку цілі
    }

    public virtual void rotationToTarget(int ang, Vector3 worldPoss) //
    {
        float dx = myTransform.position.x - worldPoss.x; // дістаємо к-ти  
        float dy = myTransform.position.y - worldPoss.y;
        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg; // вираховуємо кут
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle + ang));
        myTransform.rotation = rot; // поворот героя
    }

    public virtual void setDamage()
    {
        target.myRefScript.takeDamage(forceOfAttack, typeOfAttack);
    }
}
