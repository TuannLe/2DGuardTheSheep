using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitRun : MonoBehaviour
{
    [SerializeField]
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;


    private float timer;
    private bool checkPointA;
    private bool checkHurt;
    public float speed = 5;
    private float destroyTime = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;

        SetDestroyTime();
    }

    // Update is called once per frame
    void Update()
    {
        Run();

       
    }
    Transform GetClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject enemy in enemies)
        {
            Transform t = enemy.transform;
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    void RunTowardsEnemy(Transform enemy)
    {
        Vector3 direction = (enemy.position - transform.position).normalized;
        rb.velocity = direction * speed;
        
        if (checkHurt)
        {
            anim.SetBool("isHurt", true);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }
    }
    void Run()
    {
        if (checkHurt)
        {
            speed = 8;
            anim.SetBool("isHurt", true);
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
             
            if (transform.position.x <= pointB.transform.position.x)
            {
                Transform closestEnemy = GetClosestEnemy();
                if (closestEnemy != null)
                {
                    RunTowardsEnemy(closestEnemy);
                }
            } else {
                rb.velocity = new Vector2(-speed, 0);
            }

            anim.SetBool("IsRunning", true);
        }
       
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
}
