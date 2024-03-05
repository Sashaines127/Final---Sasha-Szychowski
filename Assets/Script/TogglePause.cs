using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePause : MonoBehaviour
{
    public GameObject pause;    // now you have to drag and drop your canvas in the editor in the script component
    public bool pauseActive; // do we have to display the canvas (true) or not (false)

    void Start()
    {
        pauseActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // if you press the Epace key
        {
            if (pauseActive == false)
            {
                Time.timeScale = 0;
            }

            else
            {
                Time.timeScale = 1;
            }

            pauseActive = !pauseActive; // change the state of your bool
            pause.SetActive(pauseActive); // display or not the canvas (following the state of the bool)
        }
    }
}