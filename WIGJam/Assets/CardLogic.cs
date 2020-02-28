using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLogic : MonoBehaviour
{
    TMP_Text tmp;
    public bool isMouseOver = false;
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
}
