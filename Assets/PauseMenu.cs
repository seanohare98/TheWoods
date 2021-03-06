using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public FirstPersonController player;

    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

        if (gameIsPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.GetComponent<FirstPersonController>().enabled = false;
            player.GetComponent<Flashlight>().enabled = false;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            player.GetComponent<FirstPersonController>().enabled = true;
            player.GetComponent<Flashlight>().enabled = true;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
