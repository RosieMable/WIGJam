using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsing : MonoBehaviour
{
    private bool coroutineAllowed;
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        coroutineAllowed = true;
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public void StartPulse()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(StartPulsing());
        }
    }
    public IEnumerator StartPulsing()
    {
        coroutineAllowed = false;
        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            rect.localScale = new Vector3(
                (Mathf.Lerp(rect.localScale.x, rect.localScale.x + 0.025f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(rect.localScale.y, rect.localScale.y + 0.025f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(rect.localScale.z, rect.localScale.z + 0.025f, Mathf.SmoothStep(0f, 1f, i)))
                );
            yield return new WaitForSeconds(0.015f);

        }

            for (float i = 0f; i <= 1f; i += 0.1f)
            {
            rect.localScale = new Vector3(
                    (Mathf.Lerp(rect.localScale.x, rect.localScale.x - 0.025f, Mathf.SmoothStep(0f, 1f, i))),
                    (Mathf.Lerp(rect.localScale.y, rect.localScale.y - 0.025f, Mathf.SmoothStep(0f, 1f, i))),
                    (Mathf.Lerp(rect.localScale.z, rect.localScale.z - 0.025f, Mathf.SmoothStep(0f, 1f, i)))
    
                    );
                yield return new WaitForSeconds(0.015f);
            }
        coroutineAllowed = true;
    }
}
