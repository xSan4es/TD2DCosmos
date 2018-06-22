using UnityEngine;

public class HeroArcher : Hero
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

    public override void setDamage()
    {
        InfoHero tempPrefab = GameController.pool.launchPrefab(NameHero.Arrow, new Vector2(myTransform.position.x, myTransform.position.y), myTransform.rotation);
        tempPrefab.myRefScript.takeDamage(forceOfAttack, typeOfAttack);
        tempPrefab.myRefScript.setTarget(target);
    }
}