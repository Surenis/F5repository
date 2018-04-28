using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointObject : respawn{

//Position of the checkpoint in space
	public Vector3 checkpoint;

	// Use this for initialization
	void Start ()
	{
		checkpoint = transform.position;
	}
	
	// How the object react on trigger
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			initpos = checkpoint;
		}
	
	}
	
}
