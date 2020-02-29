using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject WelcomeScreen, ChatScreen;

    public int blockCount;


    private void Start()
    {
        InitGame();
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
