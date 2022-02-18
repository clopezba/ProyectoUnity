using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MascarillaController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movimiento mascarillas
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.5f * Time.deltaTime, 0.0f), ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
