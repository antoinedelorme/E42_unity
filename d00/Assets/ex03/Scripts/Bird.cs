using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    private float vertical_speed = 0f;
    public GameObject explosion;
    private Vector3 _vertical_direction = new Vector3(0f, 1f,0f);
    private float _gravity = 3.75f;
    private float _thrust = 30f;
    void Start()
    {
         
    }

    public void explode(){
        GameObject obj = Instantiate(explosion,gameObject.transform.localPosition, Quaternion.identity);
		Destroy( obj, 0.25f);
        obj.transform.Translate(0f,0f,-1f);
        Destroy(gameObject);

    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2.2f)
            explode();
        

        if (Input.GetKey("space"))
        {
           vertical_speed -= _thrust*Time.deltaTime;
        }
        transform.rotation = Quaternion.identity;
        transform.Rotate(0f,0f,-vertical_speed*7f);
        vertical_speed += _gravity*Time.deltaTime;
        transform.Translate(-vertical_speed*_vertical_direction*Time.deltaTime,Space.World);
        
    }
}
