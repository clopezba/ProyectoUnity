using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminadorCoronavirus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Coronavirus")
        {
            col.gameObject.SetActive(false);
            Destroy(col.gameObject, 0.5f);
        }
    }
}

