using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// Start is called before the first frame update

	private string _up;
	private string _down;
	private float _speed;
	private float _impulse = 2.0f;
    private float _friction = 0f;
    private bool _ready = true;
    private float _speed_treshold = 0.01f;
	private float _speed_max = 4f;

	private float _x_position;

    

	void Start()
	{
		_up = (transform.position.x < 0) ? "w" : "up";
		_down = (transform.position.x < 0) ? "s" : "down";
		_x_position = (transform.position.x < 0) ? -8.75f : 8.75f;
		_speed = 0;

	}
    float ft_abs(float x){
        float y;
        y = (x>=0)?x:-x;
        return (y);
    }

	// Update is called once per frame

	void test_speed(){
		if (ft_abs(_speed)  < _speed_treshold)
                _speed = 0f;
		if (ft_abs(_speed)  > _speed_max)
                _speed = (_speed > 0) ? _speed_max : -_speed_max;
        
	}

	void test_position() {
		if (transform.position.y > 4.5f)
		{
				_speed = 0;
				transform.position = new Vector3(_x_position,4.5f,0f);
				

		}
		if (transform.position.y < -4.5f)
		{
				_speed = 0;
				transform.position = new Vector3(_x_position,-4.5f,0f);
				

		}
		
		
	}

	void Update()
	{
			if (Input.GetKeyDown(_up)){
                _speed += _impulse;
            }
				

			if (Input.GetKeyDown(_down)){
                _speed -= _impulse;
            }
				
		
		test_speed();
		transform.Translate(0f, _speed * Time.deltaTime, 0f);
        _speed = _speed * (100f-_friction*Time.deltaTime)/100f;
		test_position();
        

	}
}
