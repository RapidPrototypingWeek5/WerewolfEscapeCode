using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AudioManager : MonoBehaviour
{
    public static scr_AudioManager instance;

    public FMOD.Studio.EventInstance mainMenuMusic;
    public FMOD.Studio.EventInstance inGameMusic;
    public FMOD.Studio.EventInstance gameOverMusic;
    public FMOD.Studio.EventInstance crash;
    public FMOD.Studio.EventInstance coinCollected;
    public FMOD.Studio.EventInstance drivingLoop;
    public FMOD.Studio.EventInstance shopPurchase;

    public void Awake()
    {
        // sets the audio reference values
        instance = this;
        mainMenuMusic = FMODUnity.RuntimeManager.CreateInstance("event:/MainMenu");
        inGameMusic = FMODUnity.RuntimeManager.CreateInstance("event:/GameMusic");
        gameOverMusic = FMODUnity.RuntimeManager.CreateInstance("event:/GameOver");
        crash = FMODUnity.RuntimeManager.CreateInstance("event:/Crash");
        coinCollected = FMODUnity.RuntimeManager.CreateInstance("event:/CoinCollected");
        drivingLoop = FMODUnity.RuntimeManager.CreateInstance("event:/DrivingLoop");
        shopPurchase = FMODUnity.RuntimeManager.CreateInstance("event:/ShopPurchase");
    }
}
