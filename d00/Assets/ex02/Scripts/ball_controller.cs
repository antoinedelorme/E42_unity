using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball_controller : MonoBehaviour
{
    
    public GameObject club;
    private Vector3 _direction;
    public Text finalmessage;
    private float _attrition;
    private club_controller _cc;
    // Start is called before the first frame update

    float f_Abs(float x){
        return x >= 0 ? x : -x;
    }

    public float speed = 0f;
    private float _lower_speed = 0.01f;
    void Start()
    {
        _direction = new Vector3(0f,1f,0f);
        _attrition = 3.5f;
        _cc = club.GetComponent<club_controller>();
        finalmessage.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        

        if (f_Abs(speed) > 0){
            if (transform.position.y + speed > 4.75f)
                speed = -speed;
            
             if (transform.position.y + speed < -4.70f)
                speed = -speed;
            
           if ((f_Abs(transform.position.y - 3.34f) <0.05f) && (f_Abs(speed) < 0.03f)){
               _cc.game_ended = true;
               if (_cc._score <= 0)
                    finalmessage.text = "You won";
                else 
                    finalmessage.text = "Almost there";
               Destroy(gameObject);
        
           }
            transform.Translate(speed * _direction);
            speed = speed * (100f-_attrition)/100f;
            if (f_Abs(speed) < _lower_speed){
               if (_cc._score > 0)
                {
                    finalmessage.text = "You lost";
                }
                speed = 0;
                _cc.is_ready = true;
                _cc.transform.position =  new Vector3(_cc.transform.position.x,transform.position.y+0.34f);
            }
        }
    }
}
