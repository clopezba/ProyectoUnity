using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Musica : MonoBehaviour
{
    static Musica music = null;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioClip clip;

    
   
    private void Awake()
    {
        source.PlayOneShot(clip);
    }
    public void cambiarSonido()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
            AudioListener.volume = 0;
        } else
        {
            PlayerPrefs.SetInt("Muted", 0);
            AudioListener.volume = 1;
        }
    }
}
