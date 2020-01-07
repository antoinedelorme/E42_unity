using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

	// Use this for initialization
	private float next_time;
	private int[] choices = new int[3] { 0, 0, 0 };
	private Renderer rend;
	private int choice;
	public GameObject[] cube;
	public GameObject explosion;
	private int count = 0;
	private GameObject[] instantiated_cubes = { null, null, null };

	bool check_null()
	{
		for (int i = 0; i < 3; i++)
		{
			if (instantiated_cubes[i])
				return false;
		}
		return true;
	}

	void destroy_cube(int i)
	{
		if (choices[i] == 1)
		{
			Destroy(instantiated_cubes[i], 0.01f);
			Destroy(Instantiate(explosion,instantiated_cubes[i].transform.localPosition, Quaternion.identity), 0.1f);
			
			//rend = instantiated_cubes[i].GetComponent<Renderer>();
    		//rend.enabled = false;
 		}
	}



	void Start()
	{	
	  	next_time = Time.time + Random.Range(0.5f, 1.0f);
	}

	// Update is called once per frame
	void Update()



	{

		 if (Input.GetKeyDown("a") )
        {
			destroy_cube(0);
        }

		if (Input.GetKeyDown("s") )
        {
			destroy_cube(1);
        }

		if (Input.GetKeyDown("d") )
        {
			destroy_cube(2);
        }


		if (Time.time > next_time && count < 3)
		{
			if (count < 3)
			{
				next_time = Time.time + Random.Range(0.1f, 1.0f);
				choice = Random.Range(0, 3);
				while (choices[choice] == 1)
					choice = (choice + 1) % 3;
				choices[choice] = 1;
				instantiated_cubes[choice] = Instantiate(cube[choice]);
				count++;
			}

		}
		if (check_null())
		{
			choices = new int[3] { 0, 0, 0 };
			count = 0;
		}

	}
}
