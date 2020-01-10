using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
	Vector2 _speed;
	float _initial_speed = 3f;
	public Player left_player;
	public Player righ_player;
	private int _restart = 0;
	private int _score0 = 0;
	private int _score1 = 0;


	// Start is called before the first frame update
	void Start()
	{

		Restart(Random.Range(-1f, 1f));
	}

	void Increase_speed()
	{
		_speed = _speed.normalized * (_speed.magnitude + 0.5f);
	}

	void Restart(float direction)
	{

		float _x_speed = (direction > 0) ? 10f : -10f;
		float _y_speed = Random.Range(-15f, 15f);
		if (_restart != 0)
		{
    		_score0 = (_restart == -1) ? _score0 + 1 : _score0;
			_score1 = (_restart == 1) ? _score1 + 1 : _score1;
		}


		_restart = 0;
		_speed = new Vector2(_x_speed, _y_speed).normalized * _initial_speed;
		transform.position = new Vector2(0f, 0f);
		Debug.Log(" Player 1: " + _score0 + " | Player 2: " + _score1);
	}

	void checkbounds()
	{

		if (_restart != 0 && (transform.position.x > 9f || transform.position.x < -9f))
			Restart(_restart);
		if (transform.position.y > 4.7f)
		{
			_speed = new Vector2(_speed.x, -_speed.y);
			transform.position = new Vector2(transform.position.x, 9.4f - transform.position.y);
		}
		if (transform.position.y < -4.7f)
		{
			_speed = new Vector2(_speed.x, -_speed.y);
			transform.position = new Vector2(transform.position.x, -9.4f - transform.position.y);

		}

		if (transform.position.x > 8.45f)
		{
			if ((transform.position.y - righ_player.transform.position.y < 1.15f)
			&& (transform.position.y - righ_player.transform.position.y > -1.15f))
			{
				float _temp_speed = _speed.magnitude;
				float bonus_speed = (transform.position.y - righ_player.transform.position.y) * _temp_speed;

				_speed = new Vector2(-_speed.x, _speed.y + bonus_speed).normalized * _temp_speed;
				transform.position = new Vector2(16.9f - transform.position.x, transform.position.y);
				Increase_speed();
			}
			else
				_restart = 1;


		}
		if (transform.position.x < -8.45f)
		{
			if ((transform.position.y - left_player.transform.position.y < 1.15f)
			&& (transform.position.y - left_player.transform.position.y > -1.15f))
			{
				float _temp_speed = _speed.magnitude;
				float bonus_speed = (transform.position.y - righ_player.transform.position.y) * _temp_speed;
				_speed = new Vector2(-_speed.x, _speed.y + bonus_speed);
				transform.position = new Vector2(-16.9f - transform.position.x, transform.position.y);
				Increase_speed();
			}
			else
				_restart = -1;


		}

	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(_speed * Time.deltaTime);
		checkbounds();

	}
}
