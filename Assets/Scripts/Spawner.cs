using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] zombies = new GameObject[3];
    [SerializeField] GameObject[] spawnPoints = new GameObject[23];
    [SerializeField] AudioSource _zombieSound;
    private List<Vector3> _usedSpawnPoints = new List<Vector3>();

    private int zombieSpawnAmount = 10;
    private int _secondsBetweenSpawn = 2;

    private void Start()
    {
        StartCoroutine(SpawnZombie());
    }

    private IEnumerator SpawnZombie()
    {
        int zombieCount = 0;

        while (zombieCount < zombieSpawnAmount)
        {
            var zombie = zombies[Random.Range(0, zombies.Length)];
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            if (!_usedSpawnPoints.Contains(spawnPoint.transform.position))
            {
                GameObject newZombie = Instantiate(zombie, spawnPoint.transform.position, Quaternion.identity);
                _zombieSound.Play();
                zombieCount++;
            }

            _usedSpawnPoints.Add(spawnPoint.transform.position);

            yield return new WaitForSeconds(_secondsBetweenSpawn);
        }
    }
}