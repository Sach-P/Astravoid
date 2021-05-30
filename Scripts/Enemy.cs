using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public int points;
    public Transform player;
    private Rigidbody2D rigid;
    private Vector2 movement;
    public float moveSpeed = 5f;

    public GameObject destEffect;

    void Start()
    {

       player = GameObject.FindGameObjectWithTag("Player").transform;
       rigid = this.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigid.rotation = angle;
        direction.Normalize();
        movement = direction;

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rigid.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D other) {

        if((other.gameObject.tag == "Bullet")){

        
            FindObjectOfType<GM>().DestroyEnemy(this);
            Instantiate(destEffect, new Vector3(transform.position.x, transform.position.y, -10), Quaternion.identity);
            Destroy(other.gameObject);//bullet dissapears

        }
        
        else if (other.gameObject.tag == "Player"){
            FindObjectOfType<GM>().DestroyEnemy(this);
            Instantiate(destEffect, new Vector3(transform.position.x, transform.position.y, -10), Quaternion.identity);
        }
    }
}
