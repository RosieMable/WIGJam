using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CardLogic : MonoBehaviour
{
    public TMP_Text tmp;
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
