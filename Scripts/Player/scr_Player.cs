using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour
{
    public static scr_Player instance;

    public MeshFilter playerMesh;

    public bool isPlayerMove;
    public bool isCollidered;

    public Rigidbody rb;
    public Transform tr;
    public float moveRightLeft;
    public float baseMoveRightLeft;
    public float increaseInRightLeft;

    public float autoSpeed;
    public float baseAutoSpeed;
    public float totalAutoSpeed;

    public float baseTimer;
    public float timer;
    public float distanceTravelled;

    public float positonY;
    public float positonZ;

    public void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        // set player position
        tr.position = new Vector3(0f, positonY, positonZ);
    }

    public void Update()
    {
        // moves the player continously forward whilst allowing the player to move horizontally based on input
        if (isPlayerMove == true)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal") * 3.5f,0f,autoSpeed);
            rb.velocity = move * moveRightLeft * Time.fixedDeltaTime;
            scr_PlayerManager.instance.inGameDistanceTravelled.text = "Distance travelled: " + (distanceTravelled = tr.position.z/100f);

            // triggers the end section of the game
            if (scr_GameManager.instance.isStoryMode == true)
            {
                if (distanceTravelled >= 10 && scr_GroundSpawner.instance.endOfStoryMode == false)
                {
                    scr_GroundSpawner.instance.endOfStoryMode = true;
                    scr_GroundSpawner.instance.SpawnEnd();
                }
            }
        }

        // stops all player movement and reset values to their base values
        else
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            moveRightLeft = baseMoveRightLeft;
            timer = baseTimer;
            autoSpeed = baseAutoSpeed;
            totalAutoSpeed = baseAutoSpeed;
        }
    }

    public void FixedUpdate()
    {
        // timer for player survival time
        if (isPlayerMove == true && isCollidered == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = baseTimer;
                totalAutoSpeed = autoSpeed + 0.25f;
                autoSpeed = totalAutoSpeed;
                moveRightLeft += increaseInRightLeft;
            }
        }
        // reset timer values to base
        else if (isCollidered == false)
        {
            timer = baseTimer;
            totalAutoSpeed = baseAutoSpeed;
            autoSpeed = baseAutoSpeed;
        }
    }

    public void GameOver()
    {
        // reset values to the game over state
        rb.velocity = new Vector3(0f, 0f, 0f);
        moveRightLeft = baseMoveRightLeft;
        timer = baseTimer;
        autoSpeed = baseAutoSpeed;
        totalAutoSpeed = baseAutoSpeed;
        scr_PlayerManager.instance.playerDistance = distanceTravelled;
        distanceTravelled = 0f;
    }
}
