using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cursory : MonoBehaviour {

    private SpriteRenderer rend;

  

    void Start(){
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void Update(){

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //
        transform.position = cursorPos;
        
    }
}
