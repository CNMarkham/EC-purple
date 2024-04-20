using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 0.8f;
    private float tempTime = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
        }
        // Comparing Time.time - previous time to fallTime
        // Time.time the current time
        // previousTime is the last time been updated
        if (Time.time - previousTime > fallTime)
        {
            transform.position += Vector3.down;
            // when the previousTime gets updated
            previousTime = Time.time;
            //fallTime = tempTime;

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //tempTime = fallTime;
            //tempTime = tempTime / 10;
            
            
        }

    }
}
