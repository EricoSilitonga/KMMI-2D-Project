using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
   public void PlayButton()
    {
        AudioManager.instance.PlaySFX(3);
        SceneManager.LoadScene("Level 1");
    }

    public void QuitButton()
    {
        AudioManager.instance.PlaySFX(3);
        Application.Quit();
    }
}
