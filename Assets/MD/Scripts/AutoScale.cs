using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScale : MonoBehaviour
{
    float width;
    float height;

    private void Start()
    {
        width = transform.localScale.x;
        height = transform.localScale.y;
    }
    void Update()
    {
        float k = Screen.width / (float)Screen.height;
        if (k > 16 / 9f)
            transform.localScale = new Vector3(width * (1 + k - 16 / 9f), height * (1 + k - 16 / 9f), transform.localScale.z);
        else
            transform.localScale = new Vector3(width, height, transform.localScale.z);
    }
}
