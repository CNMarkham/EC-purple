using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tetromino : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 0.8f;
    private float tempTime = 0;
    public static int width = 10;
    public static int height = 20;
    public Vector3 rotationPoint;
    public static Transform[,] grid = new Transform[width, height];
    //            Update          is              called        once     per             frame

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 convertedPoint = transform.TransformPoint(rotationPoint);
            transform.RotateAround(convertedPoint, Vector3.forward, -90);

            if (!ValidMove())
            {
                transform.RotateAround(convertedPoint, Vector3.forward, 90);
            }
        }

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
            tempTime = tempTime / 30;
        }
        if (Time.time - previousTime > tempTime)
        {
            transform.position += Vector3.down;
            //            when         the                                  previousTime           gets            updated
            previousTime = Time.time;
            if (!ValidMove())
            {
                transform.position += Vector3.up;
                this.enabled = false;
                AddToGrid();
                CheckLines();
                FindObjectOfType<Spawner>().SpawnTetromino();
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
            if (grid[x, y] != null)
            {
                return false;
            }
        }
        return true;
    }
    public void AddToGrid()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);
            grid[x, y] = child;
        }

    }
    public void CheckLines()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeletedLine(i);
                RowDown(i);
            }
        }
    }
    public bool HasLine(int i)
    {
        for (int j=0; j < width; j++)
        {
            if (grid[j,i] == null)
            {
                return false;
            }
        }

        return true;
    }
    public void DeletedLine(int i)
    {
        for (int j = 0; j <width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }
    public void RowDown(int i)
    {
        for (int y = i; y <height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].transform.position += Vector3.down;
                }
            }
        }
    }
    
    
    
}
