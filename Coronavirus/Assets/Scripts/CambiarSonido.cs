using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarSonido : MonoBehaviour
{
    public Sprite boton_on;
    public Sprite boton_off;
    public Button btn;
    private Musica music;

    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindObjectOfType<Musica>();
        ActualizarIcono();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PausarMusica()
    {
        music.cambiarSonido();
        ActualizarIcono();
    }

    void ActualizarIcono()
    {
        if(PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 0.3f;
            btn.GetComponent<Image>().sprite = boton_on;
        } else
        {
            AudioListener.volume = 0;
            btn.GetComponent<Image>().sprite = boton_off;
        }
    }

        
}
