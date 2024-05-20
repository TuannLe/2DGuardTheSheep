using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyPos;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
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
