using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para la gestión del cursor del juego
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
     * Método que se ejecuta cuando el cursor entra en un botón de la interfaz de usuario
     * Cambia el icono del cursor, de flecha a mano
     */
    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursor_mano, cursorMano_hotspot, CursorMode.Auto);
    }

    /*
     * Método que se ejecuta cuando el cursor sale de un botón de la interfaz de usuario
     * Cambia el icono del cursor, de mano a flecha
     */
    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursor_normal, cursorNormal_hotspot, CursorMode.Auto);
    }

    /*
     * Método que se ejecuta cuando se presiona el ratón sobre un botón de la interfaz de usuario
     * Cambia el icono del cursor, de mano a mano pulsada
     */
    public void OnButtonCursorPress()
    {
        Cursor.SetCursor(cursor_manoPulsada, cursorManoPulsada_hotspot, CursorMode.Auto);
    }
}
