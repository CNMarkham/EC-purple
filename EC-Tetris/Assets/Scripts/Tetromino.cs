using System.Collections;
using System.Collections.Generic;
using UnityEngine;





































public class Tetromino : MonoBehaviour
{
                              private     float        previousTime;
             public               float                          fallTime                        = 0.8f;
                    private              float                       tempTime =           0;
                         public                       int                                                  width =                                                     10;
             public         static                  int          height                                                                               =20;
                                     //            Update          is              called        once     per             frame

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;

            if (!ValidMove())
            {
                transform.position += Vector3.right;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            if (!ValidMove())
            {
                transform.position += Vector3.left;
            }
        }
        //          Comparing    Time . time    -               previous   time   to            fallTime
        //      Time    . time       the                  current          time
        // previousTime is the last time been updated
        tempTime = fallTime;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tempTime = tempTime / 10;
        }
        if (Time.time - previousTime > tempTime)
        {
            transform.position += Vector3.down;
            //            when         the                                  previousTime           gets            updated
            previousTime = Time.time;
            if (!ValidMove())
            {
                transform.position += Vector3.up;
            }



        }


    }
    public bool ValidMove()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);
            if (x < 0)
            {
                return false;

            }
            if (y < 0)
            {

                return false;
            }
            if (y >= height)
            {
                return false;

            }
            if (x >= width)
            {
                return false;

            }
        }
        return true;
    }
}
