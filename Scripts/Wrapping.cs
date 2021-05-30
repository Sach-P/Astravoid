using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapping : MonoBehaviour
{
    public Rigidbody2D rb;
    public float screenTop;
    public float screenBottom;
    public float screenRight;
    public float screenLeft;


    // Update is called once per frame
    void Update()
    {
         //screen wrapping
        Vector2 newPos =  transform.position;
        if (transform.position.y > screenTop) {
            newPos.y = screenBottom;
        }
        if (transform.position.y < screenBottom) {
            newPos.y = screenTop;
        }
        if (transform.position.x > screenRight) {
            newPos.x = screenLeft;
        }
        if (transform.position.x < screenLeft) {
            newPos.x = screenRight;
        }
        transform.position = newPos;
    }
}
