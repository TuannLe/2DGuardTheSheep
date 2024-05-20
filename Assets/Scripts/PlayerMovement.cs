using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6;
    public float maxY = 2f;
    float movementVertical;

    // Update is called once per frame
    void Update()
    {
        movementVertical = Input.GetAxis("Vertical");
        if((movementVertical > 0 && transform.position.y < maxY) || (movementVertical < 0 && transform.position.y > (-maxY - 2f)))
        {
            transform.position += Vector3.up * movementVertical * speed * Time.deltaTime;
        }
    }

}
