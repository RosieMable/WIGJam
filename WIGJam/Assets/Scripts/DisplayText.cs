using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public string mystring;
    public Text myText;
    public float fadeTime;
    public bool displayInfo;


    void Start()
    {

        myText = GameObject.Find("Text").GetComponent<Text>();
        myText.color = Color.clear;
        //Screen.showCursor = false;
        //Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        FadeText ()
            if (Input.GetKeyDown (KeyCode.Escape))
    }
   void OnMouseOver()
    {
        displayInfo = true;
    }

    void OnMouseExit()

    {
        displayInfo = false;
    }
    void FadeText()

        if(displayinfo)
    {
        myText.text = myString;
        myText.color = Color.Lerp (myText.color, Color.white, fadeTime * Time.deltaTime);
    }

    else
{

myText.color = Color.Lerp (myText.color, Color.clear, fadeTime * Time.deltaTime);

}

