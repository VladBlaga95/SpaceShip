using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    // Use this for initialization
    public GameObject enemy;
    private GameObject instance;
    public static int nuberOfEnemies = 0;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (nuberOfEnemies ==0)
        {
            EnemyWave();
        }
	}
    void EnemyWave()
    {
        foreach (Transform transform in GetComponentsInChildren<Transform>())
        {

            if (Random.Range(0,2) == 1)
            {
                instance=Instantiate(enemy, transform.position, Quaternion.identity);
                instance.transform.parent = transform;
                nuberOfEnemies++;
            }
        }
    }
}
