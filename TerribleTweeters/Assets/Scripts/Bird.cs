using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        //prevents gravity from affecting bird at the start
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseDown() 
    {
        //turns bird red when its clicked on
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
