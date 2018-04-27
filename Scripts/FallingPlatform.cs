using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
	private bool isFalling = false;
	private float downSpeed = 0;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			isFalling = true;
			Destroy(gameObject, 10);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (isFalling)
		{
			downSpeed += Time.deltaTime/20;
			transform.position = new Vector3(transform.position.x,
				transform.position.y-downSpeed,
				transform.position.z);
		}
	}
}
