using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursor_normal;
    public Vector2 cursorNormal_hotspot;
    
    public Texture2D cursor_mano;
    public Vector2 cursorMano_hotspot;
    
    public Texture2D cursor_manoPulsada;
    public Vector2 cursorManoPulsada_hotspot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursor_mano, cursorMano_hotspot, CursorMode.Auto);
    }

    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursor_normal, cursorNormal_hotspot, CursorMode.Auto);
    }

    public void OnButtonCursorPress()
    {
        Cursor.SetCursor(cursor_manoPulsada, cursorManoPulsada_hotspot, CursorMode.Auto);
    }
}
