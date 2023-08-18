using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject Unit;
    [SerializeField]
    Text knightsUi;

    int availableKnights = 10;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && availableKnights > 0)
            GenerateUnit(true);
        if (Input.GetKeyDown(KeyCode.G))
            GenerateUnit(false);
    }

    /// <summary>
    /// Generowanie jednostek
    /// </summary>
    /// <param name="teamToAdd"></param>
    /// <returns>True dla dru¿yny gracza, false dla dru¿yny bota</returns>
    private void GenerateUnit(bool teamToAdd)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        Instantiate(Unit, worldMousePosition, Quaternion.identity).GetComponent<Unit>().isPlayerTeam = teamToAdd;
        availableKnights--;
        knightsUi.text = availableKnights.ToString();
        
    }
}
