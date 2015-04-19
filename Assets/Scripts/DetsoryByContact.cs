﻿using UnityEngine;
using System.Collections;

public class DetsoryByContact : MonoBehaviour {
	public GameObject explosion = null;
	public GameObject playerExplosion = null;

	void OnTriggerEnter(Collider otherCollider){
		Debug.Log ("otherCollider name is: " + otherCollider.name);
		if (otherCollider.tag == "Boundary") {
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if(otherCollider.tag == "Player"){
			Instantiate(playerExplosion, otherCollider.transform.position, otherCollider.transform.rotation);
		}
		Destroy(otherCollider.gameObject);
		if (gameObject.transform.parent != null) {
			Destroy (transform.parent.gameObject);
		}
		Destroy (gameObject);
	}

}
