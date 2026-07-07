using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_GroundSpawner : MonoBehaviour
{
    public static scr_GroundSpawner instance;

    public GameObject[] groundTile;
    public GameObject endTile;
    public Vector3 nextSpawnPoint;
    public bool endOfStoryMode;

    public float numberOfTilesToSpawnAtStart;

    public void Awake()
    {
        instance = this;
    }

    // when the game starts it spawns a set number of tiles at world center
    public void StartGame()
    {
        nextSpawnPoint = new Vector3(0f, 0f, 0f);
        for (int i = 0; numberOfTilesToSpawnAtStart >= i; i++)
        {
            GameObject temp = Instantiate(groundTile[0], nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        }
    }

    // spawns a random tile type in the array based on a random number generated
    public void SpawnTile()
    {
        if (endOfStoryMode == false)
        {
            int randomNum = Random.Range(0, 21);
            GameObject temp = Instantiate(groundTile[randomNum], nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        }
    }

    // spawns the end tile at the next spawn point
    public void SpawnEnd()
    {
        GameObject temp = Instantiate(endTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

}
