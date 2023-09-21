using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public GameObject player;
    //Start
    void Start()
    {
        
    }

    //Update
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stick")
        {
            player.SendMessage("Shield",false);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Coin")
        {
            player.SendMessage("AddCoin");
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Shield")
        {
            player.SendMessage("Shield", true);
            Destroy(col.gameObject);
        }
    }
}
