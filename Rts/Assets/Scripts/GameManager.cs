using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject Unit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            GenerateUnit();
    }

    private void GenerateUnit()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        Instantiate(Unit, worldMousePosition, Quaternion.identity);
    }
}
