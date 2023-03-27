using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    public float speed = 0.5f; // adjust this to control the speed of the background movement
    private Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= -5.4)
        {
            transform.position = startPosition;
        }
    }
}
