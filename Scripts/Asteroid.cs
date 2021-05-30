using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxThrust;
    public float maxTorque;
    public float screenTop;
    public float screenBottom;
    public float screenRight;
    public float screenLeft;
    public int asteroidSize; //size from larger to small, 3-large 2-medium 1-small
    public GameObject asteroidMedium;
    public GameObject asteroidSmall;

    public int points;

    public GameObject destEffect;

    // Start is called before the first frame update
    void Start()
    { //add random torque and thrust 
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range (-maxTorque, maxTorque);

        //apply generated numbers
        rb.AddForce(thrust);
        rb.AddTorque(torque);
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
    }

    void OnCollisionEnter2D(Collision2D other) {// when bullet hits asteroids

        if(other.gameObject.tag == "Bullet"){

            
            if (asteroidSize == 3){//spawn 2 medium asteroids
                Instantiate(asteroidMedium, transform.position, transform.rotation);
                Instantiate(asteroidMedium, transform.position, transform.rotation);
            }

            else if (asteroidSize == 2){//spawn 2 small asteroids
                Instantiate(asteroidSmall, transform.position, transform.rotation);
                Instantiate(asteroidSmall, transform.position, transform.rotation);
            }
        
            FindObjectOfType<GM>().DestroyAsteroid(this);
            Instantiate(destEffect, new Vector3(transform.position.x, transform.position.y, -10), Quaternion.identity);
            Destroy(other.gameObject);//bullet dissapears

        }
    }
    
}
