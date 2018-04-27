using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newlevel : MonoBehaviour
{
	public Vector3 spawn;
	

	private void OnTriggerEnter(Collider other)
	{
	//Checks if the player is able to finish the level
		if ((other.gameObject.tag == "Player") && (GameManager.CurrentCristal > 2))
		{
		//teleport the player to the "loadedscene".
			//TODO: teleport the player to a stored position rather than a computed position
			Vector3 spawn = new Vector3(0, 1, 0);
			SceneManager.LoadScene("scene2");
			transform.position = spawn;
		}
	}
}
