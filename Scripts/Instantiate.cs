using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject asteroidLarge;
    public GameObject alien;
    public GameObject player;
    public GameObject monster;
    public float respawnTime=1.0f;
    private Vector2 screenBounds;
    private int numberOfAsteroids=3;
    private int numberOfAliens=1;
    private int numberOfMonsters = 1;

    // Start is called before the first frame update
    void Start () {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy(){
        GameObject a = Instantiate(asteroidLarge) as GameObject;
        var rand = Random.Range(1,3);
        if (rand==1){
            a.transform.position = new Vector2(screenBounds.x*2, Random.Range(-screenBounds.y*2, screenBounds.y*2));
        }
        else if (rand==2) {
            a.transform.position = new Vector2(-screenBounds.x*2, Random.Range(-screenBounds.y*2, screenBounds.y*2));
        }
    }
    private void spawnAlien(){
        GameObject b = Instantiate(alien) as GameObject;
        var rand = Random.Range(1,3);
        if (rand==1){
            b.transform.position = new Vector2(screenBounds.x*2, Random.Range(-screenBounds.y*2, screenBounds.y*2));
        }
        else if (rand==2) {
            b.transform.position = new Vector2(-screenBounds.x*2, Random.Range(-screenBounds.y*2, screenBounds.y*2));
        }
    }

    private void spawnMonster(){
        GameObject c = Instantiate(monster) as GameObject;
        var rand = Random.Range(1,3);
        if (rand==1){
            c.transform.position = new Vector2(screenBounds.x*2, Random.Range(-screenBounds.y*2, screenBounds.y*2));
        }
        else if (rand==2) {
            c.transform.position = new Vector2(-screenBounds.x*2, Random.Range(-screenBounds.y*2, screenBounds.y*2));
        }
    }
    IEnumerator asteroidWave(){
        while(FindObjectOfType<GM>().alive){
            yield return new WaitForSeconds(respawnTime);
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
                for (int i=0; i<numberOfAsteroids; i++){
                    spawnEnemy();
                    yield return new WaitForSeconds(0.5f);
                }
                yield return new WaitForSeconds(5.0f);
                for (int i=0; i<numberOfAliens; i++){
                    spawnAlien();
                    yield return new WaitForSeconds(1.0f);
                }
                yield return new WaitForSeconds(8.0f);
                for (int i=0; i<numberOfMonsters; i++){
                    spawnMonster();
                    yield return new WaitForSeconds(1.0f);
                }
                numberOfAsteroids+=1;
                numberOfAliens+=1;
                numberOfMonsters+=1;
            }
        }
    }
}
