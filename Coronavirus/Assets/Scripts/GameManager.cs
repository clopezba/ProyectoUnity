using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Text vidas_txt;
    public Text mascarilla_txt;
    private PlayerController jugador;

    public GameObject[] personajes;
    public Transform posicionInicial;
    int personajeSelec;
    public GameObject jug;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        personajeSelec = PlayerPrefs.GetInt("JugadorSel", 0);
        jug = Instantiate(personajes[personajeSelec], posicionInicial.position, personajes[personajeSelec].transform.rotation);

        jugador = jug.GetComponent<PlayerController>();
    }
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
