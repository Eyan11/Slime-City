using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    private Vector2 newPosition = Vector2.zero;
    private float x = 0;
    void Update()
    {
        x += (0.1f * Time.deltaTime);

        newPosition.x = 5f * Mathf.Cos(x);
        newPosition.y = 5f * Mathf.Sin(x);

        transform.position = newPosition;
    }
}
