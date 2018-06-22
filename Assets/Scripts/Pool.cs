using UnityEngine;
using System.Collections.Generic;

public class Pool : MonoBehaviour
{
    public Transform objectsParent;

    public GameObject[] heroesGM;
    public int[] countHeroes;
    public List<InfoHero>[] heroesInPool;

    private void Awake()
    {
        heroesInPool = new List<InfoHero>[heroesGM.Length];

        for (int i = 0; i < heroesInPool.Length; i++)
        {
            heroesInPool[i] = new List<InfoHero>();

            for(int j = 0; j < countHeroes[i]; j++)
            {
                GameObject tempGO = Instantiate(heroesGM[i]);
                tempGO.SetActive(false);

                InfoHero tempInfoHero = new InfoHero();
                tempInfoHero.myGameObject = tempGO;
                tempInfoHero.myTransform = tempGO.transform;
                tempInfoHero.myRefScript = tempGO.GetComponent<TDObject>();


                heroesInPool[i].Add(tempInfoHero);
                heroesInPool[i][j].myTransform.SetParent(objectsParent);
            }
        }
    }

    public InfoHero launchPrefab(NameHero nameHero, Vector2 vectorXY, Quaternion rot)
    {
        InfoHero tempPrefab = new InfoHero();
        foreach(InfoHero prefab in heroesInPool[(int)nameHero])
        {
            if (!prefab.myGameObject.activeInHierarchy)
            {
                Vector3 tempVector = new Vector3(vectorXY.x, vectorXY.y, prefab.myTransform.position.z);

                prefab.myTransform.position = tempVector;
                prefab.myTransform.rotation = rot;
                prefab.myGameObject.SetActive(true);

                tempPrefab = prefab;
                break;
            }
        }
        return tempPrefab;
    }
}
