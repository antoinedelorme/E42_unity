using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
	// Start is called before the first frame update

	public GameObject far;
	public GameObject close;
	public GameObject pipe1;
	public GameObject pipe2;

	public Bird bird;
	private float _speed_far = 0.25f;
	private float _speed_ground = 1.5f;
	private Vector3 _direction = new Vector3(-1f, 0f, 0f);

	private float _score = 0;
	private bool _gameover = false;

	void accelerate()
	{
		_speed_ground += 0.25f;
		_speed_far = _speed_ground / 4;
		_score += 5;
	}



	void screen_refresh()
	{
		if (far.transform.position.x < 10f)
		{
			far.transform.Translate(new Vector3(4.5f, 0f, 0f));

		}
		if (pipe1.transform.position.x < -4.5f)
		{

			pipe1.transform.Translate(new Vector3(10.25f, 0f, 0f));
			pipe1.transform.position = new Vector3(pipe1.transform.position.x, Random.Range(0.25f, 2.4f), 0f);
			accelerate();
		}
		if (pipe2.transform.position.x < -4.5f)
		{
			pipe2.transform.Translate(new Vector3(10.25f, 0f, 0f));
			pipe2.transform.position = new Vector3(pipe2.transform.position.x, Random.Range(0.25f, 2.4f), 0f);
			accelerate();

		}
		if (close.transform.position.x < -1f)
		{
			close.transform.Translate(new Vector3(0.45f, 0f, 0f));
		}
		far.transform.Translate(_speed_far * _direction * Time.deltaTime);
		close.transform.Translate(_speed_ground * _direction * Time.deltaTime);
		pipe1.transform.Translate(_speed_ground * _direction * Time.deltaTime);
		pipe2.transform.Translate(_speed_ground * _direction * Time.deltaTime);
	}

	void test_collision(GameObject pipe)
	{
		if (bird.transform.position.y - pipe.transform.position.y < -1.46f
			&& bird.transform.position.x - pipe.transform.position.x > -1.52f
			&& bird.transform.position.x - pipe.transform.position.x < 0.77f)
		{
			bird.explode();
		}
		if (bird.transform.position.y - pipe.transform.position.y > 1.39f
			&& bird.transform.position.x - pipe.transform.position.x > -1.52f
			&& bird.transform.position.x - pipe.transform.position.x < 0.77f)
		{
			bird.explode();
		}
	}
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		

		if (bird)
		{
            screen_refresh();
			test_collision(pipe1);
			test_collision(pipe2);
		}
		else
		{
			if (!_gameover)
			{
				Debug.Log("Score: " + _score);
				Debug.Log("Time:" + Mathf.RoundToInt(Time.realtimeSinceStartup) + "s");
                //Debug.Log("Time: s");
				
				_gameover = true;
			}

		}


	}
}
