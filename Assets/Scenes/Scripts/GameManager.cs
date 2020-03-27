using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum Difficulty { Medium, Hard, Godlike};
    [SerializeField] private Difficulty GameDifficulty;
    public GameObject[] spawnMob;
    private int spawnMobArraySize;
    private float spawnDelta = 0.0f;
    private float spawnPointX = 0.0f;
    private float spawnPointZ = 0.0f;

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
        spawnPointX = Random.Range(-60.0f, 60.0f);
        spawnPointZ = Random.Range(-60.0f, 60.0f);
        spawnPointX = CheckMinimalDistanceSpawn(spawnPointX);
        spawnPointZ = CheckMinimalDistanceSpawn(spawnPointZ);

        if (CheckForMob())
        {
            int randomInt = Random.Range(0, spawnMobArraySize);
            Vector3 spawnPosition = new Vector3(spawnPointX, 0, spawnPointZ);
            GameObject enemy = spawnMob[randomInt];

            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }

    private float CheckMinimalDistanceSpawn(float spawnValue)
    {
        if (spawnValue <= 5f && spawnValue >= 5f)
        {
            if (spawnValue < 0)
                spawnValue -= 2;
            else
                spawnValue += 2;
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
                return 5.0f;
            case Difficulty.Hard :
                return 3.7f;
            case Difficulty.Godlike:
                return 2.5f;
            default:
                return 5.0f;
        }
    }
}
