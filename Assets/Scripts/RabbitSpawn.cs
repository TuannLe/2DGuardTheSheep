using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawn : MonoBehaviour
{

    public GameObject enemy;
    public Transform enemyPos;
    private float timer;

    // Start is called before the first frame update
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4)
        {
            timer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(enemy, enemyPos.position, Quaternion.identity);
    }
}
