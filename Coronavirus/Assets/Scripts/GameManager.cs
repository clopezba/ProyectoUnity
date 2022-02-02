using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Text vidas_txt;
    public Text mascarilla_txt;
    public PlayerController jugador;

    void Start()
    {

    }
    void Update()
    {
        if(jugador.Vidas >= 0)
        {
            vidas_txt.text = "X " + jugador.Vidas.ToString();
        } else
        {
            vidas_txt.text = "X 0";
        }
        
        mascarilla_txt.text = "X " + jugador.Mascarillas.ToString();
    }
}
