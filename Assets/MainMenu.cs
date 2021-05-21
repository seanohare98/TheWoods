using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public static bool initCall = true;

	void Start()
    {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		if (initCall)
        {
			PlayerPrefs.SetInt("Difficulty", 1);
			initCall = false;
		}
	}
	public void PlayGame(int sceneNum)
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneNum);
	}

	public void QuitGame ()
	{
		Debug.Log("QUIT!");
		Application.Quit();
	}

	public void chooseDifficulty(int difficulty)
    {
		PlayerPrefs.SetInt("Difficulty", difficulty);
    }
}
