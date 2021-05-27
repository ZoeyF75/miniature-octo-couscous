using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{   
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDragDistance = 3.5;

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
        Vector2 desiredPosition = mousePosition;

        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if (distance > _maxDragDistance) 
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition =  _startPosition + (direction * _maxDragDistance);
        }

        if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;

        _rigidbody2D.position = desiredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //collision is special paramter passed in about objects collided
    void OnCollisionEnter2D(Collision2D collision) 
    {   
        StartCoroutine(ResetAfterDelay());
    }

    //not string return type
    IEnumerator ResetAfterDelay()
    {   
        //waits three seconds
        yield return new WaitForSeconds(3);
        //resets birds postion   
        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
