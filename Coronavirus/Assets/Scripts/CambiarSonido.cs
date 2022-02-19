using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarSonido : MonoBehaviour
{
    public Sprite boton_on;
    public Sprite boton_off;
    public Button btn;
    private bool sonando = true;

    // Start is called before the first frame update
    void Start()
    {
        boton_on = btn.image.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarMusica()
    {
        if (sonando)
        {
            btn.image.sprite = boton_off;
            sonando = false;
        } else
        {
            btn.image.sprite = boton_on;
            sonando = true;
        }
    }
}
