using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameO : MonoBehaviour {
	
	public GameObject ObjectNew;
	public GameObject ObjectOld;
	public int Health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			ObjectNew.SetActive (true);
			ObjectOld.SetActive (false);
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Destroy") {
			Health -= 1;
		}
	}
}