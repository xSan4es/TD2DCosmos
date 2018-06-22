using UnityEngine;

public class TDObject : MonoBehaviour
{
    [HideInInspector]
    public Transform myTransform;
    public float maxHealth;
    [HideInInspector]
    public float health;
    [HideInInspector]
    public InfoHero target;
    public float physicalResist;
    public float magicResist;
    public Transform healthBar;
    public float healthBarScale;

    public virtual void forStart()
    {
        healthBarScale = healthBar.localScale.x;
    }

    public virtual void takeDamage(float forceOfAttack, TypeOfAttack typeOfAttack)
    {
        if(!healthBar.gameObject.activeInHierarchy) healthBar.gameObject.SetActive(true);
        if (health > 0)
        {
            if (typeOfAttack == TypeOfAttack.magical)
            {
                health -= forceOfAttack * (1 - magicResist);
            }

            else if (typeOfAttack == TypeOfAttack.physical)
            {
                health -= forceOfAttack * (1 - physicalResist);
            }

            else if (typeOfAttack == TypeOfAttack.pure)
            {
                health -= forceOfAttack;
            }

            healthBar.localScale = new Vector3((health / maxHealth) * healthBarScale, healthBar.localScale.y, healthBar.localScale.z);

            if (health <= 0)
            {
                healthBar.localScale = new Vector3(healthBarScale, healthBar.localScale.y, healthBar.localScale.z);
                healthBar.gameObject.SetActive(false);
                death();
            }
        }
    }

    public virtual void death()
    {
        gameObject.SetActive(false);
    }

    public virtual void setTarget(InfoHero target)
    {
        this.target = target;
    }
}
