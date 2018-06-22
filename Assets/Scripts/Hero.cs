using UnityEngine;

public class Hero : MovingObject
{
    public Animator animator;

    public float speedOfAttack;
    
    public override void death()
    {
        animator.speed = 1;
        animator.SetTrigger("Die");
        GameController.deleteFromList(myTransform);
    }

    public virtual void HideInHierarchy()
    {
        gameObject.SetActive(false);
    }

    public virtual void forUpdate()
    {
        distance = distanceBetweenPoints(myTransform, target.myTransform);

        if (distance <= rangeOfAttack)
        {
            animator.speed = 1 * speedOfAttack / 60;
            animator.SetTrigger("Attack");
            rotationToTarget(spriteAngle, target.myTransform.position);
        }
        else if (distance > rangeOfAttack)
        {
            animator.speed = 1;
            animator.SetTrigger("Walk");

            moveToTarget();
        }
    }

    void OnEnable()
    {
        health = maxHealth;
        healthBar.gameObject.SetActive(false);
    }
}

