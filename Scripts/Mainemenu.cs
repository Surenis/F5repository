using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainemenu : MonoBehaviour {

	public void playgame()
	{
		SceneManager.LoadScene(1); // or scenemanager.getactivescene().buildindex + 1
	}

	public void quitgame()
	{
		Debug.Log("Quit");
		Application.Quit();
	}
}