using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{

    private SpriteRenderer rend;
    public Sprite handCursor;
    public Sprite normalCursor;

    void Start(){
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if (Input.GetMouseButtonDown(0))
        {
            rend.sprite = handCursor;
        } else if (Input.GetMouseButtonUp(0))
        {
            rend.sprite = normalCursor;
        }
    }

}