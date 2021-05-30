using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float timeCounter=0;

    // Update is called once per frame
    void Update()
    {
        timeCounter+= Time.deltaTime*0.05f;

        float x = Mathf.Cos (timeCounter);
        float y = Mathf.Sin (timeCounter);
        transform.position = new Vector2 (x,y);
    }
}
