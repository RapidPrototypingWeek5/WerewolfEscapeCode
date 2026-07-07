using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_PlayerManager : MonoBehaviour
{
    public static scr_PlayerManager instance;
    public float playerCoins;
    public float playerDistance;
    public GameObject player1, player2, player3;
    public Mesh playerMesh;

    public TMP_Text inGameCoinCounter, shopCoinCounter;
    public TMP_Text inGameDistanceTravelled;

    public bool isEquippedSkin1, isEquippedSkin2, isEquippedSkin3;

    public void Awake()
    {
        instance = this;
    }

    public void OnEquipSkin()
    {
        // displays currently equipped skin
        if (isEquippedSkin1 == true)
        {
            player1.SetActive(true);
            player1.GetComponent<scr_Player>().isPlayerMove = true;
            player1.GetComponent<scr_Player>().StartGame();
        }
        else if (isEquippedSkin2 == true)
        {
            player2.SetActive(true);
            player2.GetComponent<scr_Player>().isPlayerMove = true;
            player2.GetComponent<scr_Player>().StartGame();
        }
        else if (isEquippedSkin3 == true)
        {
            player3.SetActive(true);
            player3.GetComponent<scr_Player>().isPlayerMove = true;
            player3.GetComponent<scr_Player>().StartGame();
        }
    }

    public void EndOfRun()
    {
        // disables player movement
        if (isEquippedSkin1 == true)
        {
            player1.GetComponent<scr_Player>().isPlayerMove = false;
            player1.SetActive(false);
        }
        else if (isEquippedSkin2 == true)
        {
            player2.GetComponent<scr_Player>().isPlayerMove = false;
            player2.SetActive(false);
        }
        else if (isEquippedSkin3 == true)
        {
            player3.GetComponent<scr_Player>().isPlayerMove = false;
            player3.SetActive(false);
        }
    }

    public void ObjectCollide()
    {
        // stop player moving forward as collidered
        if (isEquippedSkin1 == true)
        {
            player1.GetComponent<scr_Player>().autoSpeed = 0;
            player1.GetComponent<scr_Player>().isCollidered = true;
        }
        else if (isEquippedSkin2 == true)
        {
            player2.GetComponent<scr_Player>().autoSpeed = 0;
            player2.GetComponent<scr_Player>().isCollidered = true;
        }
        else if (isEquippedSkin3 == true)
        {
            player3.GetComponent<scr_Player>().autoSpeed = 0;
            player3.GetComponent<scr_Player>().isCollidered = true;
        }
    }
    public void ExitObjectCollide()
    {
        // enables player moving forward
        if (isEquippedSkin1 == true)
        {
            player1.GetComponent<scr_Player>().autoSpeed = player1.GetComponent<scr_Player>().totalAutoSpeed;
            player1.GetComponent<scr_Player>().isCollidered = false;
        }
        else if (isEquippedSkin2 == true)
        {
            player2.GetComponent<scr_Player>().autoSpeed = player2.GetComponent<scr_Player>().totalAutoSpeed;
            player2.GetComponent<scr_Player>().isCollidered = false;
        }
        else if (isEquippedSkin3 == true)
        {
            player3.GetComponent<scr_Player>().autoSpeed = player3.GetComponent<scr_Player>().totalAutoSpeed;
            player3.GetComponent<scr_Player>().isCollidered = false;
        }
    }

    public void GameOver()
    {
        // calls game over for the player
        if (isEquippedSkin1 == true)
        {
            player1.GetComponent<scr_Player>().GameOver();
        }
        else if (isEquippedSkin2 == true)
        {
            player2.GetComponent<scr_Player>().GameOver();
        }
        else if (isEquippedSkin3 == true)
        {
            player3.GetComponent<scr_Player>().GameOver();
        }
    }
}
