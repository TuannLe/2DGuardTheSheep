using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStoneScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force = 15;
    private float destroyTime = 4f;
    private PlayScript playScript;
    [SerializeField] private LayerMask whatDestroyStone;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetStraightVelocity();
        SetDestroyTime();
    }

    private void SetStraightVelocity()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y + 5f).normalized * force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((whatDestroyStone.value & (1 << collision.gameObject.layer)) > 0)
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Player")
        {
            playScript = FindObjectOfType<PlayScript>();
            playScript.Lives--;
            playScript.livesImage[playScript.Lives].SetActive(false);
        }
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
}
