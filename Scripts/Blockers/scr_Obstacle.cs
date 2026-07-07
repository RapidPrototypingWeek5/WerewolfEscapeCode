using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Obstacle : MonoBehaviour
{

    // when the player enters it brings them to a complete forward stop untill they move out the way
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OnTriggerEnter");
            scr_PlayerManager.instance.ObjectCollide();
        }
    }

    // when the player moves out of the way. The player then goes to the current max speed;
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OnTriggerEnter");
            scr_PlayerManager.instance.ExitObjectCollide();
        }
    }
}
