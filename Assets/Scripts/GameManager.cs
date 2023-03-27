using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject imagePrefab;
    private bool isDragging = false;
    private GameObject flappySprite;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
                flappySprite = Instantiate(imagePrefab, new Vector3(touchPosition.x, touchPosition.y, 5f), randomRotation);
                isDragging = true;
            }

            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                flappySprite.transform.position = newPosition;
                flappySprite.GetComponent<Rigidbody2D>().isKinematic = true;
            }

            else if (touch.phase == TouchPhase.Ended && isDragging)
            {
                isDragging = false;
                flappySprite.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }
}

