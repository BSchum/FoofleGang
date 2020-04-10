using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FoofleGang.Enemies;

public class GameManager : MonoBehaviour
{
    private enum Difficulty { Medium, Hard, Godlike};
    [SerializeField] private Difficulty GameDifficulty = Difficulty.Medium;
    public GameObject[] spawnMob;
    private int spawnMobArraySize;
    private float spawnDelta = 0.0f;
    private float spawnPointX = 0.0f;
    private float spawnPointZ = 0.0f;
    private float maxSpawnRange = 50.0f;
    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        spawnMobArraySize = spawnMob.Length;
    }

    // Update is called once per frame
    void Update()
    {
        spawnDelta += Time.deltaTime;
        if (spawnDelta >= GetGameDifficulty(GameDifficulty)) {
            SpawnMob();
            spawnDelta = 0.0f;
        }
    }

    private void SpawnMob()
    {
        spawnPointX = Random.Range(-maxSpawnRange, maxSpawnRange);
        spawnPointZ = Random.Range(-maxSpawnRange, maxSpawnRange);
        spawnPointX = CheckMinimalDistanceSpawn(spawnPointX);
        spawnPointZ = CheckMinimalDistanceSpawn(spawnPointZ);

        if (CheckForMob())
        {
            int randomInt = Random.Range(0, spawnMobArraySize);
            Vector3 spawnPosition = new Vector3(spawnPointX, 0, spawnPointZ);
            GameObject enemy = spawnMob[randomInt];
            enemy.GetComponent<ZombieController>().SetSpeed(0.8f);
            enemy.GetComponent<ZombieController>().SetTarget(target.transform);
            enemy.GetComponent<ZombieController>().SetRange(2.0f);


            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }

    private float CheckMinimalDistanceSpawn(float spawnValue)
    {
        if (spawnValue <= 5f && spawnValue >= 5f)
        {
            spawnValue = spawnValue < 0 ? spawnValue -= 2 : spawnValue += 2;
            return CheckMinimalDistanceSpawn(spawnValue);
        }
        else
        {
            return spawnValue;
        }
    }

    private bool CheckForMob()
    { //This is a "kind-of" loop that checks if the place is free. if not add 2 to xPos and recheck.
        if (Physics.CheckSphere(new Vector3(spawnPointX, 0.0f, spawnPointZ), 1.0f))
        {
            spawnPointX += 1;
            spawnPointZ += 1;
            return CheckForMob();
        }
        else
        {
            return true;
        }
    }

    private float GetGameDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Medium :
                return 4.3f;
            case Difficulty.Hard :
                return 3.0f;
            case Difficulty.Godlike:
                return 1.8f;
            default:
                return GetGameDifficulty(Difficulty.Medium);
        }
    }
}
