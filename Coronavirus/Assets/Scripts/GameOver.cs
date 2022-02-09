using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text record_txt;
    public Text actual_txt;
    //private PlayerController jugador;

    // Start is called before the first frame update
    void Start()
    {
        //jugador = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        record_txt.text = "Record ............... " + PlayerPrefs.GetInt("Mascarillas").ToString();
        //actual_txt.text = jugador.Mascarillas.ToString();
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
    
}
