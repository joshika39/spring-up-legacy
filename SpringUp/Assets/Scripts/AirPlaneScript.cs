using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneScript : MonoBehaviour
{
    Vector3 dir;
    Quaternion localRotation;
    float speed = 30f;
    float m_Speed = 5f;
    public Rigidbody2D playerRB;
    //Start
    void Start()
    {
        localRotation = transform.rotation;
    }

    //Update
    void Update()
    {
        //dir.x = Input.acceleration.x * 5;
        //transform.position += new Vector3(dir.x,0,0);
        float curSpeed = Time.deltaTime * speed;
        localRotation.z = -Input.acceleration.x * curSpeed;
        transform.rotation = localRotation;
        playerRB.velocity = transform.right * m_Speed;
    }
}
