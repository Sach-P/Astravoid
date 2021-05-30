using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500.0f;
    public float maxLifeTime = 10.0f;
    
    private Rigidbody2D rb;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 dir){
        rb.AddForce(dir * this.speed);

        Destroy(this.gameObject, this.maxLifeTime);

    }
}
