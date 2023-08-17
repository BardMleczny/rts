using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Unit : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public bool isSelected = false;
    Vector2 target;
    readonly float speed = 0.01f;
    Vector3 mousePos;
    KeyCode groupId;
    public bool isPlayerTeam;
    
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = new Vector2(transform.position.x, transform.position.y);
    }
    public void Update()
    {
        if(isPlayerTeam)
        {
            PickUnit();
            CreateControlGroup();

            if (Math.Abs(transform.position.x - target.x) > speed)
                Move();
        }

        if(isSelected)
            spriteRenderer.color = new Color(255, 255, 0);
        else if(isPlayerTeam)
            spriteRenderer.color = new Color(255, 255, 255);
        else
            spriteRenderer.color = new Color(255, 0, 0);
    }

    private void Move()
    {
        float distanceX = target.x - transform.position.x;
        float distanceY = target.y - transform.position.y;
        float distance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        transform.position = new Vector3(
            transform.position.x + distanceX / distance * speed,
            transform.position.y + distanceY / distance * speed,
            transform.position.z);
    }

    private void PickUnit()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && isSelected && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            isSelected = false;
        }
        else if (Input.GetMouseButtonDown(0) && Math.Abs(transform.position.x - mousePos.x) < transform.localScale.x / 2 && Math.Abs(transform.position.y - mousePos.y) < transform.localScale.x / 2 &&
                isSelected && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            isSelected = false;
        }
        else if (Input.GetMouseButtonDown(0) && Math.Abs(transform.position.x - mousePos.x) < transform.localScale.x / 2 && Math.Abs(transform.position.y - mousePos.y) < transform.localScale.x / 2)
        {
            isSelected = true;
        }

        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            target = mousePos;
            isSelected = false;
        }
    }

    private void CreateControlGroup()
    {
        KeyCode[] numbers = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5 };
        if (Input.GetKey(KeyCode.LeftControl))
        {
            foreach (KeyCode keyCode in numbers)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    if (isSelected)
                        groupId = keyCode;
                    else if (keyCode == groupId)
                        groupId = KeyCode.None;
                }
            }
        }

        if (!Input.GetKey(KeyCode.LeftControl))
        {
            foreach (KeyCode keyCode in numbers)
            {
                if (Input.GetKeyDown(keyCode) && keyCode == groupId)
                    isSelected = true;
                else if (Input.GetKeyDown(keyCode) && keyCode != groupId && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                    isSelected = false;
            }
        }
    }

    public void SetTeam(bool isPlayerTeam)
    {
        this.isPlayerTeam = isPlayerTeam;
    }
}
