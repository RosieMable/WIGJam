using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    public GameObject card;
    public CardLogic cl;
    SpriteRenderer sr;
    float fMovingSpeed = 1f;
    void Start()
    {
        sr = card.GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (Input.GetMouseButton(0) && cl.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            card.transform.position = pos;
        }
        else
        {
            card.transform.position = Vector2.MoveTowards(card.transform.position, new Vector2(0, 0), fMovingSpeed);
        }
        //checking the side
        if (card.transform.position.x > 2)
        {
            sr.color = Color.green;
            if (!Input.GetMouseButton(0))
            {
                cl.InduceRight();
            }
        }
        else if (card.transform.position.x < -2)
        {
            sr.color = Color.red;
            if (!Input.GetMouseButton(0))
            {
                cl.InduceLeft();
            }
        }
        else
        {
            sr.color = Color.white;
        }
    }
}