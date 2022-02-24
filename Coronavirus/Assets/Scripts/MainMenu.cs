using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioClip clip;
    
    // Start is called before the first frame update
    void Start()
    {
  
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
        SceneManager.LoadScene("CoronAttack");

    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Has salido de la aplicación");
    }
}
