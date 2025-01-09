using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    float zoomSpeed = 50f;
    bool inSky = false;
    Vector3 skyPos = new Vector3(70f, 90f, 50f);
    Vector3 skyRot = new Vector3(90f, 0f, 0f);
    Vector3 groundPos;
    Vector3 groundRot;

    // Update is called once per frame
    void Update()
    {
        if (!inSky && Input.GetKeyDown(KeyCode.C))
        {
            groundPos = transform.position;
            groundRot = transform.eulerAngles;
            StartCoroutine(MoveFromTo(transform.position, skyPos, transform.eulerAngles, skyRot));
        }
        if (inSky && Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(MoveFromTo(transform.position, groundPos, transform.eulerAngles, groundRot));
        }
    }

    IEnumerator MoveFromTo(Vector3 a, Vector3 b, Vector3 rotA, Vector3 rotB)
    {
        float step = (zoomSpeed / (a - b).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step;
            transform.position = Vector3.Lerp(a, b, t); //move object closer to b
            transform.eulerAngles = Vector3.Lerp(rotA, rotB, t); //move object closer to b
            yield return new WaitForFixedUpdate(); //leave routine and return in the next frame
        }
        inSky = !inSky;
    }
    public void OnClick()
    {
        Application.Quit();
    }
}