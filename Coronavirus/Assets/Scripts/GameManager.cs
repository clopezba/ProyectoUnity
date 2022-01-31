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
        vidas_txt.text = "X " + jugador.Vidas.ToString();
        mascarilla_txt.text = "X " + jugador.Mascarillas.ToString();
    }
}
