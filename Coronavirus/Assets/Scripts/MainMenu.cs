using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Jugar()
    {
        SceneManager.LoadScene("CoronAttack");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Has salido de la aplicaci�n");
    }
}
