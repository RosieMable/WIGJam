using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameLogic : MonoBehaviour
{

    public GameObject card;
    public CardLogic cl;
    [SerializeField] private Transform handPoint;
    public Transform canvas;
    Image sr;
    float fMovingSpeed = 1f;
    void Start()
    {
        sr = card.GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cl.isMouseOver)
        {
            //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //card.transform.position = pos;
            if (card.transform.parent == canvas)
            {
                card.transform.SetParent(handPoint);
            }
            else
            {
                card.transform.SetParent(canvas);
            }
        }
        else
        {
           //card.transform.position = Vector2.MoveTowards(card.transform.position, cl.originalPosition, fMovingSpeed);           
        }
        //checking the side
        if (card.transform.position.x > 2)
        {
            //sr.color = Color.green;
            if (!Input.GetMouseButton(0))
            {
                cl.InduceRight();
            }
        }
        else if (card.transform.position.x < -2)
        {
            //sr.color = Color.red;
            if (!Input.GetMouseButton(0))
            {
                cl.InduceLeft();
            }
        }
        else
        {
            //sr.color = Color.white;
        }
    }
}