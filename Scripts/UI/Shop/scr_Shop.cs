using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_Shop : MonoBehaviour
{
    public static scr_Shop instance;

    public GameObject buyButton, equipButton;

    public Mesh car1Mesh, car2Mesh, car3Mesh, currentMesh;
    public bool isBought1, isBought2, isBought3;
    public bool isEquiped1, isEquiped2, isEquiped3;

    public Sprite car1Sprite, car2Sprite, car3Sprite;
    public Image currentCar, nextCar, pastCar;
    public float price;
    public TMP_Text priceBox;

    public void Awake()
    {
        // set default values
        instance = this;
        isBought1 = true;
        isEquiped1 = true;
        scr_PlayerManager.instance.playerMesh = car1Mesh;
        scr_PlayerManager.instance.OnEquipSkin();
        equipButton.SetActive(false);
    }

    public void OnOpenShop()
    {
        // shows default car as the first car in the shop
        scr_PlayerManager.instance.shopCoinCounter.text = "Coins: " + scr_PlayerManager.instance.playerCoins;
        currentCar.sprite = car1Sprite;
        currentMesh = car1Mesh;
        nextCar.sprite = car2Sprite;
        pastCar.sprite = car3Sprite;

        // shows button available for the car based on the car status
        if (isBought1 == false)
        {
            buyButton.SetActive(true);
            equipButton.SetActive(false);
            priceBox.text = "Buy Skin - " + price + " gold";
        }
        else if(isEquiped1 == false)
        {
            equipButton.SetActive(true);
            buyButton.SetActive(false);
        }
        else
        {
            equipButton.SetActive(false);
            buyButton.SetActive(false);
        }
    }

    public void NextSkin()
    {
        // shows the next car in the shop and the button based on the car statud
        if (currentCar.sprite == car1Sprite)
        {
            currentCar.sprite = car2Sprite;
            currentMesh = car2Mesh;
            nextCar.sprite = car3Sprite;
            pastCar.sprite = car1Sprite;

            if (isBought2 == false)
            {
                buyButton.SetActive(true);
                equipButton.SetActive(false);
                priceBox.text = "Buy Skin - " + price + " gold";
            }
            else if (isEquiped2 == false)
            {
                equipButton.SetActive(true);
                buyButton.SetActive(false);
            }
            else
            {
                equipButton.SetActive(false);
                buyButton.SetActive(false);
            }
        }
        else if(currentCar.sprite == car2Sprite)
        {
            currentCar.sprite = car3Sprite;
            currentMesh = car3Mesh;
            nextCar.sprite = car1Sprite;
            pastCar.sprite = car2Sprite;
            if (isBought3 == false)
            {
                buyButton.SetActive(true);
                equipButton.SetActive(false);
                priceBox.text = "Buy Skin - " + price + " gold";
            }
            else if (isEquiped3 == false)
            {
                equipButton.SetActive(true);
                buyButton.SetActive(false);
            }
            else
            {
                equipButton.SetActive(false);
                buyButton.SetActive(false);
            }
        }
        else if(currentCar.sprite == car3Sprite)
        {
            currentCar.sprite = car1Sprite;
            currentMesh = car1Mesh;
            nextCar.sprite = car2Sprite;
            pastCar.sprite = car3Sprite;
            if (isBought1 == false)
            {
                buyButton.SetActive(true);
                equipButton.SetActive(false);
                priceBox.text = "Buy Skin - " + price + " gold";
            }
            else if (isEquiped1 == false)
            {
                equipButton.SetActive(true);
                buyButton.SetActive(false);
            }
            else
            {
                equipButton.SetActive(false);
                buyButton.SetActive(false);
            }
        }
    }

    public void OnBuy()
    {
        // if player can buy
        if (scr_PlayerManager.instance.playerCoins >= price)
        {
            // is bought and equipped button is shown
            if (currentCar.sprite == car1Sprite && isBought1 == false)
            {
                isBought1 = true;
                equipButton.SetActive(true);
                buyButton.SetActive(false);
                scr_PlayerManager.instance.playerCoins -= price;
                scr_AudioManager.instance.shopPurchase.start();
            }
            else if (currentCar.sprite == car2Sprite && isBought2 == false)
            {
                isBought2 = true;
                equipButton.SetActive(true);
                buyButton.SetActive(false);
                scr_PlayerManager.instance.playerCoins -= price;
                scr_AudioManager.instance.shopPurchase.start();
            }
            else if (currentCar.sprite == car3Sprite && isBought3 == false)
            {
                isBought3 = true;
                equipButton.SetActive(true);
                buyButton.SetActive(false);
                scr_PlayerManager.instance.playerCoins -= price;
                scr_AudioManager.instance.shopPurchase.start();
            }
        }
        scr_PlayerManager.instance.shopCoinCounter.text = "Coins: " + scr_PlayerManager.instance.playerCoins;
    }

    public void OnEquip()
    {
       // car equip button disappears and the variable for car equipped status is changed
        equipButton.SetActive(false);
        if (currentCar.sprite == car1Sprite)
        {
            isEquiped1 = true;
            isEquiped2 = false;
            isEquiped3 = false;
            scr_PlayerManager.instance.isEquippedSkin1 = true;
            scr_PlayerManager.instance.isEquippedSkin2 = false;
            scr_PlayerManager.instance.isEquippedSkin3 = false;
        }
        else if (currentCar.sprite == car2Sprite)
        {
            isEquiped1 = false;
            isEquiped2 = true;
            isEquiped3 = false; 
            scr_PlayerManager.instance.isEquippedSkin1 = false;
            scr_PlayerManager.instance.isEquippedSkin2 = true;
            scr_PlayerManager.instance.isEquippedSkin3 = false;
        }
        else if (currentCar.sprite == car3Sprite)
        {
            isEquiped1 = false;
            isEquiped2 = false;
            isEquiped3 = true; 
            scr_PlayerManager.instance.isEquippedSkin1 = false;
            scr_PlayerManager.instance.isEquippedSkin2 = false;
            scr_PlayerManager.instance.isEquippedSkin3 = true;
        }
    }

}
