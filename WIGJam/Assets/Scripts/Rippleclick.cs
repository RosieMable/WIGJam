using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rippleclick : MonoBehaviour
{
    public GameObject obj;
    public float waitTime = 1;

    GameObject reference;

    void Start()
    {
        reference.SetActive(false);
    }

    void Update()
    {
         WaitThenDestroy();
    }

    void WaitThenDestroy()
    {
        if (Input.GetMouseButtonDown(0) && reference.activeInHierarchy == false)
            reference.SetActive(true);

        if (Input.GetMouseButtonDown(0) && reference.activeInHierarchy == true)
            reference.SetActive(false);
    }
}