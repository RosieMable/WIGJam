using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameLogic : MonoBehaviour
{

    public RectTransform card;
    public CardLogic cl;
    [SerializeField] private Transform handPoint;
    [SerializeField] RectTransform Like, Dislike, CenterPoint;
    public Transform canvas;
    Image sr;
    float fMovingSpeed = 1f;

    public float LikeDistance, DislikeDistance;
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

        LikeDistance = Vector3.Distance(card.position, Like.position);
        DislikeDistance = Vector3.Distance(card.position, Dislike.position);

        if(DislikeDistance <= 10)
        {
            cl.InduceLeft();
        }

        if(LikeDistance <= 15)
        {
            cl.InduceRight();
        }
    }


    public void DragCard()
    {
        if (card.transform.parent == canvas)
        {
            card.transform.SetParent(handPoint);
        }
    }

    public void ReleaseCard()
    {
        card.transform.SetParent(canvas);
        card.transform.position = Vector3.Lerp(card.transform.position, CenterPoint.position, 0.3f);
    }
}