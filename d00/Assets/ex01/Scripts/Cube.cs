using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {


	private float speed; 
	// Use this for initialization
	void Start () {
		speed = Random.Range(0.10f, 0.15f);
	}
	

	// Update is called once per frame
	void Update () {
	     transform.position += new Vector3(0, -speed, 0);
		 if (transform.position.y < (- 5))
		{
			Destroy(gameObject);
		}
      	
	}
}
