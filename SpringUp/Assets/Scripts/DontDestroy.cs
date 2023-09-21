using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public AudioSource audiodata;
    private void Start()
    {
        if(!audiodata.isPlaying)
        {
            audiodata.Play();
        }
        
    }
    void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);   
    }
}
