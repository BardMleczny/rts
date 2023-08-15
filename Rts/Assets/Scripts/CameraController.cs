using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    Vector2 startingMousePos = new Vector2();

    public float zoomSpeed = 5.0f;
    public float minFOV = 20.0f;
    public float maxFOV = 60.0f;
    void Update()
    {
        Move();
        Zoom();
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

        /*if (Input.mousePosition.x >= Screen.width - 50)
            transform.position += moveSpeed * Time.deltaTime * Vector3.right;
        if (Input.mousePosition.x <= 50)
            transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        if (Input.mousePosition.y >= Screen.height - 50)
            transform.position += moveSpeed * Time.deltaTime * Vector3.up;
        if (Input.mousePosition.y <= 50)
            transform.position += moveSpeed * Time.deltaTime * Vector3.down;
        */
    }

    void Zoom()
    {
        float zoomSpeed = 5.0f;
        float minZoom = 3.0f;
        float maxZoom = 10.0f;
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        float newZoom = Camera.main.orthographicSize - scrollInput * zoomSpeed;

        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

        Camera.main.orthographicSize = newZoom;
    }
}
