using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject WelcomeScreen, ChatScreen;

    public int blockCount;
    public int niceGuy;
    public int scum;


    public Text niceGuyUI, blockCountUI;

    private CardLogic card;

    AudioSource audio;
    private void Start()
    {
        InitGame();

        audio = FindObjectOfType<AudioSource>();
    }

    private void Update()
    {
        niceGuyUI.text = "Dates: " + niceGuy.ToString();
        blockCountUI.text = "Duds: " + blockCount.ToString();
    }

    public void ToChatService()
    {
        WelcomeScreen.SetActive(false);
        ChatScreen.SetActive(true);
    }

    public void ToFindDate()
    {
        WelcomeScreen.SetActive(true);
        ChatScreen.SetActive(false);
    }

    void InitGame()
    {
        ToFindDate();
        blockCount = 0;
    }



}
