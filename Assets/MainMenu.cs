using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame(int sceneNum)
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneNum);
	}

	public void QuitGame ()
	{
		Debug.Log("QUIT!");
		Application.Quit();
	}
}
