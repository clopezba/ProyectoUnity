using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para la gesti�n del cursor del juego
 */
public class CursorManager : MonoBehaviour
{
    public Texture2D cursor_normal;
    public Vector2 cursorNormal_hotspot;
    
    public Texture2D cursor_mano;
    public Vector2 cursorMano_hotspot;
    
    public Texture2D cursor_manoPulsada;
    public Vector2 cursorManoPulsada_hotspot;

    /*
     * M�todo que se ejecuta cuando el cursor entra en un bot�n de la interfaz de usuario
     * Cambia el icono del cursor, de flecha a mano
     */
    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursor_mano, cursorMano_hotspot, CursorMode.Auto);
    }

    /*
     * M�todo que se ejecuta cuando el cursor sale de un bot�n de la interfaz de usuario
     * Cambia el icono del cursor, de mano a flecha
     */
    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursor_normal, cursorNormal_hotspot, CursorMode.Auto);
    }

    /*
     * M�todo que se ejecuta cuando se presiona el rat�n sobre un bot�n de la interfaz de usuario
     * Cambia el icono del cursor, de mano a mano pulsada
     */
    public void OnButtonCursorPress()
    {
        Cursor.SetCursor(cursor_manoPulsada, cursorManoPulsada_hotspot, CursorMode.Auto);
    }
}
