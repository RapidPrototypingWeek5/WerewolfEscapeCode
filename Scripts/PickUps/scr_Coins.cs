using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Coins : MonoBehaviour
{
    public void OnTriggerEnter (Collider other)
    {
        // player gains a coin, upon entering and the coin object is destroyed
        if (other.tag == "Player")
        {
            scr_AudioManager.instance.coinCollected.start();
            scr_PlayerManager.instance.playerCoins++;
            scr_PlayerManager.instance.inGameCoinCounter.text = "Coins: " + scr_PlayerManager.instance.playerCoins;
            Destroy(gameObject);
        }
    }
}
