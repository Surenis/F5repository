using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour {
	public int value;
	// Use this for initialization
	void Start ()
	{
		value = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			FindObjectOfType<GameManager> ().AddCristal (value);
			Destroy (gameObject);
		}
	}
		
}
