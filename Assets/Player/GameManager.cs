using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool Recording = true;
    public bool IsPaused = false;

    private float initialfixedDeltatime;

    private void Start()
    {
        initialfixedDeltatime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update ()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            Recording = false;
        }
        else
        {
            Recording = true;
        }

        if(Input.GetKeyDown(KeyCode.P) && IsPaused)
        {
            IsPaused = false;
            ResumeGame();
        }else if(Input.GetKeyDown(KeyCode.P) && !IsPaused)
        {
            IsPaused = true;
            PauseGame();
        }
	}

    void  PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = initialfixedDeltatime;
    }
}

