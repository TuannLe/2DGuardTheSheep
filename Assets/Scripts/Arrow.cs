using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Arrow : MonoBehaviour
{
    private float speed = 15f;
    private float destroyTime = 3f;
    private Rigidbody2D rb;
    private PlayScript playScript;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetStraightVelocity();
        SetDestroyTime();
    }

    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * speed;
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject, 0);
            playScript = FindObjectOfType<PlayScript>();
            playScript.Score += 10;
            playScript.CounterScore();

            playScript.Kill++;
            playScript.CounterKill();
        }
         else if (other.tag == "Rabbit")
        {
            Destroy(gameObject);
            Destroy(other.gameObject); // Destroy the rabbit
            playScript.Score -= 10;
            playScript.CounterScore();
        }
    }
}
