using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public void selectScene()
    {

        switch (this.gameObject.name)
        {
            case "Scene01Button":
                SceneManager.LoadScene("Scene01");
                break;
            case "Scene02Button":
                SceneManager.LoadScene("Scene02");
                break;
            case "Scene03Button":
                SceneManager.LoadScene("Scene03");
                break;
        }

    }
}
