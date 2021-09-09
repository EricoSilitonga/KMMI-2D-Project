using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private Transform transform;
    private Transform playerTransform;
    private Animator anim;
    void Start()
    {
        transform = GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimation();
        CheckForPlayer();
    }

    void CheckAnimation()
    {
        anim.SetBool("On", isPlayerInRange);
    }

    bool CheckForPlayer()
    {
        if(Vector2.Distance(transform.position,playerTransform.position) < 5f)
        {
            return isPlayerInRange = true;
        }
        else
        {
            return isPlayerInRange = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().GameOver();

        }
    }
}
