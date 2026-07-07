using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_GameManager : MonoBehaviour
{
    public static scr_GameManager instance;

    public GameObject MainMenu, ShopMenu, InGameMenu, GameOverLoseMenu, GameOverWinMenu;

    public GameObject player1, player2, player3, enemy;
    public bool isGamePlayed, isStoryMode;

    public TMP_Text gameOverLose, gameOverWin;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        // sets all the values to their base states to prevent errors
        scr_AudioManager.instance.mainMenuMusic.start();
        player1.SetActive(true);
        player2.SetActive(true);
        player3.SetActive(true);
        ShopMenu.SetActive(true);
        ShopMenu.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        enemy.SetActive(false);
    }


    public void StoryMode()
    {
        // sets all values to story mode, starting the game
        scr_AudioManager.instance.mainMenuMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        scr_AudioManager.instance.inGameMusic.start();
        scr_AudioManager.instance.drivingLoop.start();
        scr_GroundSpawner.instance.endOfStoryMode = false;
        isStoryMode = true;
        InGameMenu.SetActive(true);
        MainMenu.SetActive(false);
        isGamePlayed = true;
        scr_GroundSpawner.instance.StartGame();
        scr_PlayerManager.instance.OnEquipSkin();
        enemy.SetActive(true);
        scr_Player.instance.isPlayerMove = true;
        scr_Enemy.instance.isEnemyMove = true;
        scr_Enemy.instance.StartGame();
        scr_PlayerManager.instance.inGameCoinCounter.text = "Coins: " + scr_PlayerManager.instance.playerCoins;
    }

    public void EndLess()
    {
        // sets all values to endless mode and starting game
        scr_AudioManager.instance.mainMenuMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        scr_AudioManager.instance.inGameMusic.start();
        scr_AudioManager.instance.drivingLoop.start();
        scr_GroundSpawner.instance.endOfStoryMode = false;
        isStoryMode = false;
        InGameMenu.SetActive(true);
        MainMenu.SetActive(false);
        isGamePlayed = true;
        scr_GroundSpawner.instance.StartGame();
        scr_PlayerManager.instance.OnEquipSkin();
        enemy.SetActive(true);
        scr_Player.instance.isPlayerMove = true;
        scr_Enemy.instance.isEnemyMove = true;
        scr_Enemy.instance.StartGame();
        scr_PlayerManager.instance.inGameCoinCounter.text = "Coins: " + scr_PlayerManager.instance.playerCoins;
    }

    public void Main()
    {
        // opens main menu and closes other menus
        scr_AudioManager.instance.mainMenuMusic.start();
        scr_AudioManager.instance.gameOverMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        MainMenu.SetActive(true);
        ShopMenu.SetActive(false);
        GameOverLoseMenu.SetActive(false);
        GameOverWinMenu.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
    }

    public void ExitShop()
    {
        // opens main menu and closes other menus
        MainMenu.SetActive(true);
        ShopMenu.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
    }

    public void Shop()
    {
        //opens shop menu and closes main menu
        scr_PlayerManager.instance.OnEquipSkin();
        ShopMenu.SetActive(true);
        MainMenu.SetActive(false);
        scr_Shop.instance.OnOpenShop();
        scr_PlayerManager.instance.shopCoinCounter.text = "Coins: " + scr_PlayerManager.instance.playerCoins;
    }

    public void Lose()
    {
        // set all values to the lose state
        scr_AudioManager.instance.inGameMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        scr_AudioManager.instance.drivingLoop.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        scr_AudioManager.instance.gameOverMusic.start();
        scr_PlayerManager.instance.EndOfRun();
        scr_Enemy.instance.isEnemyMove = false;
        isGamePlayed = false;
        player1.transform.position = new Vector3(0f, 0.75f, 0f);
        player2.transform.position = new Vector3(0f, 0.028f, 0f);
        player3.transform.position = new Vector3(0f, 0.1f, 0.648f);
        enemy.transform.position = new Vector3(0f, 0.75f, -10f);
        scr_PlayerManager.instance.GameOver();
        GameOverLoseMenu.SetActive(true);
        InGameMenu.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        enemy.SetActive(false);
        Debug.Log("LoseFunction");
        gameOverLose.text = "You made it" + "\r\n" + scr_PlayerManager.instance.playerDistance + " meters";
    }

    public void Win()
    {
        // set all values to the win state
        scr_AudioManager.instance.inGameMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        scr_AudioManager.instance.drivingLoop.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        scr_AudioManager.instance.gameOverMusic.start();
        scr_PlayerManager.instance.EndOfRun();
        scr_Enemy.instance.isEnemyMove = false;
        isGamePlayed = false;
        player1.transform.position = new Vector3(0f, 0.75f, 0f);
        player2.transform.position = new Vector3(0f, 0.028f, 0f);
        player3.transform.position = new Vector3(0f, 0.1f, 0.648f);
        enemy.transform.position = new Vector3(0f, 0.75f, -10f);
        scr_PlayerManager.instance.GameOver();
        GameOverWinMenu.SetActive(true);
        InGameMenu.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        enemy.SetActive(false);
        gameOverWin.text = "Congratulations! You escaped!";
    }

    public void Quit()
    {
        // exits application
        Application.Quit();
    }
}
