using UnityEngine;
using System.Collections;

public class CameraFollowScript: MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public Camera camera;

    //Start
    void Start()
    {
        
    }

    //Update
    void Update()
    {
        if (target)
        {
            if (target.transform.position.y < 30 && target.transform.position.y > 3)
            {
                Vector3 point = camera.WorldToViewportPoint(target.position);           
                Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                Vector3 destination = transform.position + delta;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }
            else
            {
                Vector3 point = camera.WorldToViewportPoint(target.position);
                Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                Vector3 destination = transform.position + delta;
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(destination.x,transform.position.y,transform.position.z), ref velocity, dampTime);
            }
           
        }

    }
}