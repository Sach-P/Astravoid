using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public int setLives = 3;
    [SerializeField]
    private int lives;//player lives
    public Text livesText;
    public Player player;
    public GameObject shield;
    public float respawnTime = 0.5f;
    public float invincibleTime = 2.0f;
    public int score = 0;
    public Text scoreText;
    public bool alive;
  
    public CameraShake cameraShake;
    [SerializeField]
    private float shakeMag;
    [SerializeField]
    private float shakeDur;

    private void Awake(){
        lives = setLives;
        livesText.text = "Lives " + lives;
        scoreText.text = "Score " + score;
        alive=true;
    }

    public void PlayerDeath(){
        this.lives--;
        this.livesText.text = "Lives " + lives; 

        if (this.lives <= 0) {
            FindObjectOfType<UI>().GameOver();
            alive=false;
        }
        else{
            Invoke(nameof(Respawn), this.respawnTime);
        }
        StartCoroutine(cameraShake.Shake(shakeDur, shakeMag));
    }

    private void Respawn(){
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        shield.SetActive(true);
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
        
        Invoke(nameof(TurnOnCollision), this.invincibleTime);
    }

    private void TurnOnCollision(){
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
        shield.SetActive(false);
    }

    public void DestroyAsteroid(Asteroid a)
    {
        
        this.score += a.points;
        this.scoreText.text = "Score " + score;
        StartCoroutine(cameraShake.Shake(shakeDur, shakeMag));
        Destroy(a.gameObject); 
    }

    public void DestroyEnemy(Enemy e)
    {
        
        this.score += e.points;
        this.scoreText.text = "Score " + score;
        StartCoroutine(cameraShake.Shake(shakeDur, shakeMag));
        Destroy(e.gameObject); 
    }
    public void DestroyAlien(Alien a)
    {
        this.score += a.points;
        this.scoreText.text = "Score " + score;
        StartCoroutine(cameraShake.Shake(shakeDur, shakeMag));
        Destroy(a.gameObject); 
    }

}
