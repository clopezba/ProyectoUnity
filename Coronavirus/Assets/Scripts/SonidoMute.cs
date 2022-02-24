using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoMute : MonoBehaviour
{
    private int mute;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    void Awake()
    {
        mute = PlayerPrefs.GetInt("Mute");
    }


    // Start is called before the first frame update    
    void Start()
    {
        if (mute == 0)
        {
            source.mute = false;
        }
        else
        {
            source.mute = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
