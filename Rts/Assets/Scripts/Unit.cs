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
    float speed = 0.01f;
    Vector3 mousePos;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = new Vector2(transform.position.x, transform.position.y);
    }
    public void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Math.Abs(transform.position.x - mousePos.x) < transform.localScale.x / 2 && Math.Abs(transform.position.y - mousePos.y) < transform.localScale.x / 2 && isSelected)
        {
            isSelected = false;
            spriteRenderer.color = new Color(255, 255, 255);
        }
        else if (Input.GetMouseButtonDown(0) && Math.Abs(transform.position.x - mousePos.x) < transform.localScale.x / 2 && Math.Abs(transform.position.y - mousePos.y) < transform.localScale.x / 2) 
        { 
            isSelected = true;
            spriteRenderer.color = new Color(255, 255, 0);
        }
        
        if (Input.GetMouseButtonDown(1) && isSelected) 
        {
            target = mousePos;
            isSelected = false;
            spriteRenderer.color = new Color(255,255,255);
        }
        if (Math.Abs(transform.position.x - target.x) > speed)
            Move();
        
    }
    public void Move()
    {
        float distanceX = target.x - transform.position.x;
        float distanceY = target.y - transform.position.y;
        float distance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        transform.position = new Vector3(
            transform.position.x + distanceX / distance * speed,
            transform.position.y + distanceY / distance * speed,
            transform.position.z);
    }
}
