using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text record_txt;
    public Text actual_txt;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioClip clip;
    
    public Sprite carmen_img;
    public Sprite fernando_img;
    public Image img;

    void Awake()
    {
        ActualizarImagen();    
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        record_txt.text = "Record ............... " + PlayerPrefs.GetInt("Mascarillas").ToString();
        actual_txt.text = "Punt. actual ......... " + PlayerPrefs.GetInt("Mascarillas_actuales").ToString();
    }

    public void Jugar()
    {
        SceneManager.LoadScene("CoronAttack");
    }
    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Salir() 
    {
        Application.Quit();
        Debug.Log("Has salido de la aplicación");
    }
    public void ReproducirSonido()
    {
        gameObject.AddComponent<AudioSource>();
        source.PlayOneShot(clip);
    }

    void ActualizarImagen()
    {
        if (PlayerPrefs.GetInt("JugadorSel") == 0)
        {
            
            img.GetComponent<Image>().sprite = carmen_img;
        }
        else
        {
            
            img.GetComponent<Image>().sprite = fernando_img;
        }
    }

}
