using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardLogic : MonoBehaviour, IDragHandler
{
    public TMP_Text tmp;
    public bool isMouseOver = false;
    public Vector3 originalPosition;
    public Canvas myCanvas;
    [SerializeField] private Transform handPoint;
    public Transform canvas;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnMouseOver()
    {
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }
    public void InduceRight()
    {
        print("You have swiped right");
    }
    public void InduceLeft()
    {
        print("You have swiped left");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
