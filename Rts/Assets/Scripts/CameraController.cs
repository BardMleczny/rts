using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 30.0f;
    Vector2 startingMousePos = new Vector2();
    void Update()
    {
        Move();
    }
    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        transform.Translate(movement);

        if (Input.GetMouseButtonDown(2))
        {
            startingMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
        {
            transform.Translate(new Vector3((startingMousePos.x - Input.mousePosition.x) / 100, (startingMousePos.y - Input.mousePosition.y) / 100, 0));
            startingMousePos = Input.mousePosition;
        }
    }
}
