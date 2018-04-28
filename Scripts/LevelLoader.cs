using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour
{

	public GameObject loadingscreen;
	public Slider slider;
	public Text ProgressText;
	public void LoadLevel(int sceneIndex)
	{
	//	loadingscreen.SetActive((true));
		StartCoroutine(LoadAsync(sceneIndex));
	}

	IEnumerator LoadAsync(int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
		
		loadingscreen.SetActive((true));
		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);
			slider.value = progress;
			ProgressText.text = progress * 100 + "%";
			yield return null;
		}
	}
}
