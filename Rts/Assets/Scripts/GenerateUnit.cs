using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateUnit : MonoBehaviour
{
    [SerializeField]
    GameObject Unit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(Unit, worldMousePosition, Quaternion.identity);
        }
    }
}
