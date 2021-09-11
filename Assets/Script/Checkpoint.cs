using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private bool finalLevel;
    [SerializeField]
    private string nextScene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (finalLevel)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                AdManager.instance.PlayAd();
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
