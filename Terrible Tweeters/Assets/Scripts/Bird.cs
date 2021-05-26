using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{   
    [SerializeField] float _launchForce = 500;

    Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;

    void Awake() 
    {
        //chaching the variables
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {   
        _startPosition = _rigidbody2D.position;
        //prevents gravity from affecting bird at the start
        _rigidbody2D.isKinematic = true;
    }

    void OnMouseDown() 
    {
        //turns bird red when its clicked on
        _spriteRenderer.color = Color.red;
    }

    void OnMouseUp() 
    {
        //vector 2 has x and y variables
        Vector2 currentPostion = _rigidbody2D.position;
        Vector2 direction = _startPosition - currentPostion;
        direction.Normalize(); //normalized vector
        _spriteRenderer.color = Color.white;

        _rigidbody2D.isKinematic = false;
        //add force in direction times 5
        _rigidbody2D.AddForce(direction * _launchForce);
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
