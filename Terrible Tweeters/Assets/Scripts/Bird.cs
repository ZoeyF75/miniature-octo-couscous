using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{   
    Vector2 _startPosition;

    // Start is called before the first frame update
    void Start()
    {   
        _startPosition = GetComponent<Rigidbody2D>().position;
        //prevents gravity from affecting bird at the start
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseDown() 
    {
        //turns bird red when its clicked on
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnMouseUp() 
    {
        //vector 2 has x and y variables
        Vector2 currentPostion = GetComponent<Rigidbody2D>().position;
        Vector2 direction = _startPosition - currentPostion;
        direction.Normalize(); //normalized vector
        GetComponent<SpriteRenderer>().color = Color.white;

        GetComponent<Rigidbody2D>().isKinematic = false;
        //add force in direction times 5
        GetComponent<Rigidbody2D>().AddForce(direction * 500);
    }

    void OnMouseDrag() 
    {   
        //3D postional vector
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
