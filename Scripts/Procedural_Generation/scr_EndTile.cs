using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EndTile : MonoBehaviour
{
    // when the player exits a tile, spawns a new tile and deletes this tile
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("GameOver");
            scr_GameManager.instance.Win();
            Destroy(gameObject, 2f);
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
