using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] dinoToSpawn;
    public int dinoCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDino());
    }

    Vector3 getRandomPos()
    {
        float _x = Random.Range(-8, 8);
        float _y = Random.Range(-4, 4);
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
}
