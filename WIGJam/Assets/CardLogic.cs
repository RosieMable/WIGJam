using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text tmp;
    public bool isMouseOver = false;
    public Vector2 originalPosition;
    public Canvas myCanvas;

    private void Start()
    {
        originalPosition = transform.position;
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, myCanvas.transform.position, myCanvas.worldCamera, out originalPosition);
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
        tmp.text = "You have swiped right";
    }
    public void InduceLeft()
    {
        tmp.text = "You have swiped left";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }
}
