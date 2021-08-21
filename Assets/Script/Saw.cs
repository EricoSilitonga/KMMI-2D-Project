using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private Vector3 startPos;
    public Vector3 endPos;

    public Transform enemy;
    public float moveSpeed;
    private bool isMovingToTarget;

    private void Start()
    {
        startPos = enemy.position;
        isMovingToTarget = true;
        enemy = GetComponent<Transform>();
    }

     void Update()
    {
        if (isMovingToTarget == true)
        {
            enemy.position = Vector3.MoveTowards(enemy.position, endPos, moveSpeed * Time.deltaTime);

            if (enemy.position == endPos)
            {
                isMovingToTarget = false;
            }
        }
        else
        {
            enemy.position = Vector3.MoveTowards(enemy.position, startPos, moveSpeed * Time.deltaTime);

            if (enemy.position == startPos)
            {
                isMovingToTarget = true;
            }
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().GameOver();

        }
    }
}
