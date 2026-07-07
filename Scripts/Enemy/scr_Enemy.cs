using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Enemy : MonoBehaviour
{
    // allows other scripts to call upon this script
    public static scr_Enemy instance;

    // variables for the enemy to move
    public bool isEnemyMove;
    public Rigidbody rb;
    public Transform tf;

    public float baseMovementSpeed;
    public float movementSpeed;

    public float forwardsMultiplayer;
    public float baseforwardsMultiplater;

    public float baseTimer;
    public float timer;

    // declares that this script is what is referenced
    public void Awake()
    {
        instance = this;
    }

    // if the enemy can move then it moves forward based upon multiple factors
    public void Update()
    {
        if (isEnemyMove == true)
        {
            Vector3 move = new Vector3(0f, 0f, movementSpeed);
            rb.velocity = move * forwardsMultiplayer * Time.fixedDeltaTime;
        }
    }

    // A timer which is active when the enemy can move and when it reaches 0 or below, increases the enemy speed. But when the enemy can't move the speed is reset to starting values
    public void FixedUpdate()
    {
        if (isEnemyMove == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = baseTimer;
                movementSpeed += 0.25f;
                forwardsMultiplayer += 5f;
            }
        }
        else
        {
            timer = baseTimer;
            movementSpeed = baseMovementSpeed;
            forwardsMultiplayer = baseforwardsMultiplater;
        }
    }

    // When player collides, game ends
    public void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Lose");
            scr_AudioManager.instance.crash.start();
            scr_GameManager.instance.Lose();
        }
    }

    // sets enemy position and values at game start
    public void StartGame()
    {
        tf.position = new Vector3 (0f, 0f, -10f);
        timer = baseTimer;
        movementSpeed = baseMovementSpeed;
        forwardsMultiplayer = baseforwardsMultiplater;
    }

}
