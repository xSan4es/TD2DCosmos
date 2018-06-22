using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private float min = -12;
    private float max = 13;
    private float timeNextUpdateDistance = 1f;

    public GameObject tableHero;

    public static Pool pool;
    public static InfoHero monstrTower = new InfoHero();
    public static InfoHero humanTower = new InfoHero();
    public static InfoHero targetMonstr = new InfoHero();
    public static InfoHero targetHuman = new InfoHero();
    public static Vector2 humanCreate = new Vector2(-17, 0);
    public static Vector2 monstrCreate = new Vector2(17, 0);
    public static List<InfoHero> monstrHeroes = new List<InfoHero>();
    public static List<InfoHero> humanHeroes = new List<InfoHero>();

    private void Start ()
    {
        pool = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Pool>();

        humanTower.myGameObject = GameObject.FindGameObjectWithTag("HumanTower");
        humanTower.myRefScript = humanTower.myGameObject.GetComponent<TDObject>();
        humanTower.myTransform = humanTower.myGameObject.transform;
        targetMonstr = humanTower;

        monstrTower.myGameObject = GameObject.FindGameObjectWithTag("MonstrTower");
        monstrTower.myRefScript = monstrTower.myGameObject.GetComponent<TDObject>();
        monstrTower.myTransform = monstrTower.myGameObject.transform;
        targetHuman = monstrTower;
    }

    private void Update ()
    {
        //if (timeNextUpdateDistance <= 0)
        //{
        //    timeNextUpdateDistance = 0.5f;
        //    fight();
        //}
        //timeNextUpdateDistance -= Time.deltaTime;
        fight();
    }

    public static void deleteFromList(Transform hero)
    {
        int i = 0;

        if(hero.tag == "Human")
        {
            foreach (InfoHero infoHero in humanHeroes)
            {
                if (infoHero.myTransform.Equals(hero)) break;
                i++;
            }
            humanHeroes.RemoveAt(i);
        }
        else if (hero.tag == "Monstr")
        {
            foreach (InfoHero infoHero in monstrHeroes)
            {
                if (infoHero.myTransform.Equals(hero)) break;
                i++;
            }

            monstrHeroes.RemoveAt(i);
        }
    }

    public static void fight()
    {
        int i = 0;
        float distance = 1000;
        int target = 0;

        if (humanHeroes.Count == 0)
            targetMonstr = humanTower;
        else
        {
            i = 0;
            distance = 1000;
            target = 0;

            foreach(InfoHero tempInfoHero in humanHeroes)
            {
                float tempDistance = distanceBetweenPoints(new Vector2(tempInfoHero.myTransform.position.x, tempInfoHero.myTransform.position.y), monstrCreate);
                if (tempDistance < distance)
                {
                    distance = tempDistance;
                    target = i;
                }
                i++;
            }

            targetMonstr = humanHeroes[target];
        }

        foreach (InfoHero tempInfoHero in monstrHeroes) tempInfoHero.myRefScript.setTarget(targetMonstr);

        if (monstrHeroes.Count == 0)
            targetHuman = monstrTower;
        else
        {
            i = 0;
            distance = 1000;
            target = 0;
            foreach (InfoHero tempInfoHero in monstrHeroes)
            {
                float tempDistance = distanceBetweenPoints(new Vector2(tempInfoHero.myTransform.position.x, tempInfoHero.myTransform.position.y), humanCreate);
                if (tempDistance < distance)
                {
                    distance = tempDistance;
                    target = i;
                }
                i++;
            }

            targetHuman = monstrHeroes[target];
        }

        foreach (InfoHero tempInfoHero in humanHeroes) tempInfoHero.myRefScript.setTarget(targetHuman);
    }

    public static float distanceBetweenPoints(Vector2 point1, Vector2 point2)
    {
        return (((point2.x - point1.x) * (point2.x - point1.x)) + ((point2.y - point1.y) * (point2.y - point1.y))) / 10;
    }

    #region createHero
    public void choiseHero()
    {
        tableHero.SetActive(true);
    }

    public void closeChoiseHero()
    {
        tableHero.SetActive(false);
    }

    public void createHumanTank()
    {
        humanHeroes.Add(pool.launchPrefab(NameHero.HumanTank, new Vector2(humanCreate.x, Random.Range(min, max)), transform.rotation));
        humanHeroes[humanHeroes.Count - 1].myRefScript.setTarget(targetHuman);
    }

    public void createMonstrTank()
    {
        monstrHeroes.Add(pool.launchPrefab(NameHero.MonstrTank, new Vector2(monstrCreate.x, Random.Range(min, max)), transform.rotation));
        monstrHeroes[monstrHeroes.Count - 1].myRefScript.setTarget(targetMonstr);
    }

    public void createHumanLDD()
    {
        humanHeroes.Add(pool.launchPrefab(NameHero.HumanLDD, new Vector2(humanCreate.x, Random.Range(min, max)), transform.rotation));
        humanHeroes[humanHeroes.Count - 1].myRefScript.setTarget(targetHuman);
    }

    public void createMonstrLDD()
    {
        monstrHeroes.Add(pool.launchPrefab(NameHero.MonstrLDD, new Vector2(monstrCreate.x, Random.Range(min, max)), transform.rotation));
        monstrHeroes[monstrHeroes.Count - 1].myRefScript.setTarget(targetMonstr);
    }

    public void createHumanArcher()
    {
        humanHeroes.Add(pool.launchPrefab(NameHero.HumanArcher, new Vector2(humanCreate.x, Random.Range(min, max)), transform.rotation));
        humanHeroes[humanHeroes.Count - 1].myRefScript.setTarget(targetHuman);
    }

    public void createMonstrArcher()
    {
        monstrHeroes.Add(pool.launchPrefab(NameHero.MonstrArcher, new Vector2(monstrCreate.x, Random.Range(min, max)), transform.rotation));
        monstrHeroes[monstrHeroes.Count - 1].myRefScript.setTarget(targetMonstr);
    }
    #endregion
}
