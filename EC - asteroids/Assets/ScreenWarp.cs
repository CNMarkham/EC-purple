using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWarp : MonoBehaviour
{
    private Vector2 screenMin;
    private Vector2 screenMax;
    // Start is called before the first frame update
    void Start()
    {
        screenMin = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        screenMax = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        //left slide
        if (x > screenMax.x)
        {
            transform.position = new Vector2(screenMin.x, y);
        }
        //right slide
        if (x < screenMin.x)
        {
            transform.position = new Vector2(screenMax.x, y);
        }
        //top slide
        if (y > screenMax.y)
        {
            transform.position = new Vector2(x, screenMin.y);
        }
        //bottom slide
        if (y < screenMin.y)
        {
            transform.position = new Vector2(x, screenMax.y);
        }
        
    }
}
