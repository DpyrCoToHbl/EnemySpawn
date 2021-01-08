using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] zombies = new GameObject[3];

    private int zombieSpawnAmount = 12;
    private int _secondsBetweenSpawn = 2;

    private void Start()
    {
        StartCoroutine(spawnZombie());
    }

    private IEnumerator spawnZombie()
    {
        int zombieCount = 0;
        while (zombieCount < zombieSpawnAmount)
        {
            int spawnPositionX = Random.Range(-8, 2);
            int spawnPositionY = Random.Range(-4, 4);

            var zombie = zombies[Random.Range(0, zombies.Length)];

            GameObject newObject = Instantiate(zombie, new Vector3(spawnPositionX, spawnPositionY, 0), Quaternion.identity);

            zombieCount++;

            yield return new WaitForSeconds(_secondsBetweenSpawn);
        }
    }
}