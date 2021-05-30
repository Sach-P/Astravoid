using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Bullet bullet;
    public UI ui;

    public CameraShake cameraShake;
    [SerializeField]
    private float shakeMag;
    [SerializeField]
    private float shakeDur;
    
    public Rigidbody2D rb;
    private Vector3 target;
    public float speed = 1.0f;
    public float dashSpeed = 50.0f;
    public float turnSpeed = 1.0f;
    private bool _thrust;
    private bool _dashUp;
    private float _turn;

    public GameObject destEffect;
    public AudioSource audio;


    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Start () {
         
    }

    private void Update()
    {
        _thrust = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        _dashUp = Input.GetKeyDown(KeyCode.LeftShift);

        if(_dashUp){
            rb.AddForce(this.transform.up * this.dashSpeed);
        }

        if(ui.getMouseState() == false){
            if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
                _turn = 1.0f;
            }
            else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
                _turn = -1.0f;
            }
            else{
                _turn = 0.0f;
            }
        }

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && ui.getPaused() == false){
            Shoot();
        }
    }

    private void FixedUpdate(){
        if(_thrust){
            rb.AddForce(this.transform.up * this.speed);
        }

        if(_turn != 0.0f){
            rb.AddTorque(_turn * this.turnSpeed);
        } 

    }

    private void Shoot(){
        Bullet bullet = Instantiate(this.bullet, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
        StartCoroutine(cameraShake.Shake(shakeDur, shakeMag));
    }

    void OnCollisionEnter2D(Collision2D col) {//when u hit an asteroid
        if (col.gameObject.tag == "Enemy") { 
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;
            
            this.gameObject.SetActive(false);
            FindObjectOfType<GM>().PlayerDeath();
            Instantiate(destEffect, new Vector3(transform.position.x, transform.position.y, -10), Quaternion.identity);
        }

    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Laser")){
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;
            this.gameObject.SetActive(false);
            FindObjectOfType<GM>().PlayerDeath();
            Instantiate(destEffect, new Vector3(transform.position.x, transform.position.y, -10), Quaternion.identity);
        }
    }
}