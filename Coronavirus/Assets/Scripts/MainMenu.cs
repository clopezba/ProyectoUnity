using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioClip clip;
    public GameObject creditos_pn;
    public GameObject instrucciones_pn;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReproducirSonido()
    {
       source.PlayOneShot(clip);
    }

    public void Jugar()
    {
        SceneManager.LoadScene("SeleccionPersonaje");
    }

    public void Creditos()
    {
        creditos_pn.SetActive(true);
    }
    public void creditosCerrar()
    {
        creditos_pn.SetActive(false);
    }

    public void Instrucciones()
    {
        instrucciones_pn.SetActive(true);
    }
    public void instruccionesCerrar()
    {
        instrucciones_pn.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Has salido de la aplicación");
    }
}
