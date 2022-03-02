using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Script que se ejecuta a lo largo de las distintas escenas del juego y determina el clip de audio y si está silenciado ono
 */
public class Musica : MonoBehaviour
{
   private AudioSource source { get { return GetComponent<AudioSource>(); } }
   public AudioClip clip;

    
    /*
     * Método que se ejecuta al cargar el script
     * Reproduce el clip de audio asignado
     */
    private void Awake()
    {
        source.PlayOneShot(clip);
    }

    /*
     * Método que recibe las preferencias sobre la configuración de sonido establecidas en la escena de menú
     * y las aplica a la escena actual
     */
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
