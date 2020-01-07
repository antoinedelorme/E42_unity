using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class club_controller : MonoBehaviour
{
	public GameObject ball;
	public int _score {
        get;
        private set;
    }


	public bool is_ready;
	private float _energy;
	public Text score_label;
	public bool game_ended = false;

	private float _accumulated_energy;
	private ball_controller _bc;
	private Vector3 move_down = new Vector3(0f, -0.05f, 0f);
	// Start is called before the first frame update
	void Start()
	{
		is_ready = true;
		_energy = 0;
        _score = -15;
		_accumulated_energy = 0;
		_bc = ball.GetComponent<ball_controller>();
        score_label.text = "Score: " + _score;
	}



	// Update is called once per frame
	void Update()
	{
		if (game_ended == false)
		{
			if (Input.GetKey("space") && is_ready == true)
			{
				_energy++;
				_accumulated_energy = _energy;
				transform.Translate(move_down);
				if (_energy == 15)
					is_ready = false;

			}
			else
		if (_energy > 0)
			{
				_energy--;
				transform.Translate(-move_down);
			}
			if (_energy == 0 && _accumulated_energy > 0)
			{
				_score += 5;
				score_label.text = "Score: " + _score;
				_bc.speed = 0.015f * _accumulated_energy;
				_accumulated_energy = 0;
			}

		}



	}
}
