using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] dinoToSpawn;
    public GameObject[] plantToSpawn;
    public int dinoCount;
    public int plantCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDino());
        StartCoroutine(PlantSpawn());
    }

    Vector3 getRandomPos()
    {
        float _x = Random.Range(-75000, 75000)/10000;
        float _y = Random.Range(-40000, 40000)/10000;
        float _z = 0.5f;

        Vector3 newPos = new Vector3(_x, _y, _z);
        return newPos;
    }

    IEnumerator SpawnDino()
    {
        while (dinoCount < Random.Range (3,5))
        {
            Instantiate(dinoToSpawn[Random.Range(0, 4)], getRandomPos(), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            dinoCount += 1;
        }
    }

    IEnumerator PlantSpawn()
    {
        while (plantCount < Random.Range(3, 5))
        {
            Instantiate(plantToSpawn[Random.Range(0, 4)], getRandomPos(), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            plantCount += 1;
        }
    }
}
