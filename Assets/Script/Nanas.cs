using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nanas : MonoBehaviour
{
    private int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().AddScore(value);
            Destroy(gameObject);
        }
    }
    

}
