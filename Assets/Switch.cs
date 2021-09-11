using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private bool inRange;
    public GameObject objectToSwitchOff;
    private bool isOn;
    public GameObject switches1;
    public GameObject switches2;
    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isOn = !isOn;
                if (isOn)
                {
                    switches2.SetActive(false);
                    switches1.SetActive(true);
                }
                else
                {
                    switches1.SetActive(false);
                    switches2.SetActive(true);
                }
                
                objectToSwitchOff.SetActive(isOn);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = false;
        }
    }
}
