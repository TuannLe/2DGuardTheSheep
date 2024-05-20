using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawn : MonoBehaviour
{

    public GameObject enemy;
    public Transform enemyPos;
    private float timer;
    private bool isFirstCall = true;
    private float initialDelay = 2f;
    private float minInterval = 15f;
    private float maxInterval = 25f;


    void Update()
    {
        if (isFirstCall)
        {
            initialDelay -= Time.deltaTime;
            if (initialDelay <= 0)
            {
                Spawn();
                isFirstCall = false;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > Random.Range(minInterval, maxInterval))
            {
                timer = 0;
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        Instantiate(enemy, enemyPos.position, Quaternion.identity);
    }
}
