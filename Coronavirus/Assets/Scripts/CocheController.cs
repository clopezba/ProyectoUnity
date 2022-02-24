using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-200.0f*Time.deltaTime, 0.0f);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FixedUpdate();
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
