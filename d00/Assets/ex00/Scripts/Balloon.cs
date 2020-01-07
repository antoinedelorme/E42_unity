using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

	// Use this for initialization
	private float decrease = -0.02f;
	private float increase = +0.20f;
	private float starttime;
	private float elapsed_time;
	private float temps_recuperation;
	private int essouflement = 0; 
	 
	void Start () {
		starttime = Time.time;
		temps_recuperation = Time.time + 0.25f;
	}

	void Finish(){
				elapsed_time = Mathf.RoundToInt(-starttime +Time.time);
				 Debug.Log("Baloon life time:" + elapsed_time);
				 Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		 if (Time.time > temps_recuperation)
		 {
			 essouflement = (essouflement == 0 ? 0 : essouflement - 1);
			 temps_recuperation = Time.time + 0.30f;

		 }
		 if (transform.localScale.x < 0.1f)
		 	Finish();
		 if (transform.localScale.x > 4.0f)
		 		 Finish();
		transform.localScale += new Vector3(decrease ,decrease, decrease);

		 if (Input.GetKeyDown("space") && essouflement <= 5)
        {
			essouflement += 1;
            transform.localScale += new Vector3(increase, increase, increase);
        }
	}
}
