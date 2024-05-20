using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitRun : MonoBehaviour
{
    [SerializeField]
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;


    private bool checkHurt;
    public float speed = 5;
    private float destroyTime = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

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
    }
    void Run()
    {
        if (checkHurt)
        {
            speed = 8;
            anim.SetBool("isHurt", true);
            rb.velocity = new Vector2(0, -speed);
        }
        else if (transform.position.x >= pointB.transform.position.x)
        {
            Transform closestEnemy = GetClosestEnemy();
            if (closestEnemy != null)
            {
                anim.SetBool("isFly", true);
                RunTowardsEnemy(closestEnemy);
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
            anim.SetBool("isRunning", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            if (checkHurt)
            {
                Destroy(gameObject, 0);
            }
        }
        else if (other.tag == "Arrow")
        {
            checkHurt = true;
            //Destroy(gameObject, 0);
        }
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
}
