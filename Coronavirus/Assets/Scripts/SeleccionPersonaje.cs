using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionPersonaje : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }    
    }

    public void onCarmenPress()
    {
        PlayerPrefs.SetInt("JugadorSel", 0);
        SceneManager.LoadScene("CoronAttack");
    }
    
    public void onFernandoPress()
    {
        PlayerPrefs.SetInt("JugadorSel", 1);
        SceneManager.LoadScene("CoronAttack");
    }

    
}
