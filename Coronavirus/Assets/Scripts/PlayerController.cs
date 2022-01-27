using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float fuerza = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        rb2D.AddForce(new Vector2(fuerza, 0), ForceMode2D.Impulse);
    //    }
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        rb2D.AddForce(new Vector2(-1 * fuerza, 0), ForceMode2D.Impulse);
    //    }
    //    if (Input.GetButton("Jump"))
    //    {
    //        rb2D.AddForce(transform.up * fuerza * 100);
    //    }



    //}
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddForce(new Vector2(fuerza, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddForce(new Vector2(-1 * fuerza, 0), ForceMode2D.Impulse);
        }
        if (Input.GetButton("Jump"))
        {
            rb2D.AddForce(transform.up * fuerza * 100);
        }
    }

}
