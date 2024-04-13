using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public GameObject The;
    public Slider Thee;
    void Update()
    {
        Thee.value = The.transform.position.x;
    }
}
