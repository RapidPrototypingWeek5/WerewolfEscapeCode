using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_GroundTile : MonoBehaviour
{

    // when the player exits a tile, spawns a new tile and deletes this tile
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            scr_GroundSpawner.instance.SpawnTile();
            Destroy(gameObject, 5f);
        }
    }

    // when the game ends all the tiles delete themselves
    public void FixedUpdate()
    {
        if (scr_GameManager.instance.isGamePlayed == false)
        {
            Destroy(gameObject, 0f);
        }
    }
}
