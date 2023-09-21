using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject scriptmanager;
    //Start
    void Start()
    {
        scriptmanager = GameObject.Find("ScriptManager");
    }

    //Update
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            ///scriptmanager.SendMessage("Ground");
            Debug.Log("asd");
        }
    }
}
