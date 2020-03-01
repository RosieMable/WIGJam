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


    public Text niceGuyUI, blockCountUI;


    public GameObject GameUI;
    public GameObject VictoryUI;

    AudioSource audio;
    private void Start()
    {
        InitGame();

    }

    private void Update()
    {
        niceGuyUI.text = "Dates: " + niceGuy.ToString();
        blockCountUI.text = "Duds: " + blockCount.ToString();

        CompleteGame();
    }

    void CompleteGame()
    {
        if (niceGuy > 0)
        {
            GameUI.SetActive(false);
            VictoryUI.SetActive(true);
        }
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
        niceGuy = 0;
        audio = FindObjectOfType<AudioSource>();
        GameUI.SetActive(true);
        VictoryUI.SetActive(false);

    }



}
