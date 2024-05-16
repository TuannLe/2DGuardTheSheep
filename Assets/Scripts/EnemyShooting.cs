using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShooting : MonoBehaviour
{
    public GameObject stone;
    public Transform stonePos;

    public GameObject pointA;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    private PlayScript playScript;

    private float timer;
    private bool checkPointA;
    private bool checkHurt;
    public float speed = 5;
    private float destroyTime = 20f;
    private float randomNumber = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointA.transform;
        SetDestroyTime();
        randomNumber = Random.Range(2f, 13f);
    }

    // Update is called once per frame
    void Update()
    {
        Run();

        timer += Time.deltaTime;
        if (timer > 5 && checkPointA == true)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(stone, stonePos.position, Quaternion.identity);
    }

    void Run()
    {
        if (checkHurt)
        {
            speed = 8;
            anim.SetBool("isHurt", true);
            rb.velocity = new Vector2(0, -speed);
        } 
        else if (checkPointA)
        {
            speed = 3.5f;
            anim.SetBool("IsRunning", false);
            rb.velocity = new Vector2(0, -speed);

        }
        else
        {
            anim.SetBool("IsRunning", true);
            rb.velocity = new Vector2(speed, 0);
        }

        
        if (Vector2.Distance(transform.position, currentPoint.position) < randomNumber)
        {
            checkPointA = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            checkPointA = false;
            playScript = FindObjectOfType<PlayScript>();
            playScript.Lives--;
            playScript.livesImage[playScript.Lives].SetActive(false);
            if (checkHurt)
            {
                Destroy(gameObject, 0);
            }
        } 
         else if(other.tag == "Arrow")
        {
            checkHurt = true;
            checkPointA = false;
            //Destroy(gameObject, 0);
        }
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
}
