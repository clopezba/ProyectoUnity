using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para generar el efecto Parallax en el fondo de la escena
 */
public class MoverFondos : MonoBehaviour
{
    public GameObject[] fondos;
    public float[] velocidadFondos;
    public float[] tamanyoFondos;

    /*
     * Método que se ejecuta una vez por fotograma
     * Ejecuta el método MueveFondos
     */
    void Update()
    {
        MueveFondos();
    }

    /*
     * Método que mueve los fondos con efecto Parallax 
     * Cada uno se mueve a una velocidad para dar efecto de profundidad
     */
    private void MueveFondos()
    {
        for (int i = 0; i < fondos.Length; i++)
        {
            if(Mathf.Abs(fondos[i].transform.localPosition.x) > tamanyoFondos[i])
            {
                //Regresa el fondo a su posición orginal
                fondos[i].transform.localPosition = new Vector3(0.0f, fondos[i].transform.localPosition.y, fondos[i].transform.localPosition.z);
            }
            else
            {
                //Moviendo el fondo
                float offset = Time.deltaTime * velocidadFondos[i];
                fondos[i].transform.localPosition += new Vector3(offset, 0.0f);
            }
        }
    }
}
