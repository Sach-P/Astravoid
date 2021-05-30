using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 direction;
    public float speed;
    public float screenTop;
    public float screenBottom;
    public float screenRight;
    public float screenLeft;
    public float shootingDelay;
    public float lastTimeShot=0f;
    public float bulletSpeed;
    public float bulletLifeTime;

    public int points;

    public Transform player;
    public GameObject bullet;
    public GameObject destEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

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

        if (Time.time > lastTimeShot + shootingDelay){ //making sure enough time has passed between shots
            //shoot
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

            //instantiate bullet
            GameObject newBullet = Instantiate(bullet, transform.position, q);
            Destroy(newBullet.gameObject, bulletLifeTime);

            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletSpeed));
            lastTimeShot = Time.time; //updating last time shot
        }
    }
    
    void FixedUpdate()
    {//figure out which way to approach player
        direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction*speed* Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D other) {// when bullet hits asteroids

        if(other.gameObject.tag == "Bullet"){

            FindObjectOfType<GM>().DestroyAlien(this);
            Instantiate(destEffect, new Vector3(transform.position.x, transform.position.y, -10), Quaternion.identity);
            Destroy(other.gameObject);//bullet dissapears

        }
    }
}
