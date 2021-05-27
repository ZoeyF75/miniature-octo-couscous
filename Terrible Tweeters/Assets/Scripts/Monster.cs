using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
        {
            Die();
        }
    }

    bool ShouldDieFromCollision(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null) 
            return true;

        //noraml y -0.5 colliding object is coming from above
        if (collision.contacts[0].normal.y < -0.5)
            return true;

        return false;
    }   

    void Die()
    {   
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        // gameObject.SetActive(false);
    }
}
