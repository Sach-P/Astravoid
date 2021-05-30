using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCardBackground : MonoBehaviour
{
    public GameObject monster;
    public GameObject alien;
    public GameObject asteroidSmall;
    public GameObject asteroidMedium;

    public float respawnTime=3.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start () {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy(){
        int random= Random.Range (0, 3);
        if (random==0)
        {
            GameObject a = Instantiate(alien) as GameObject;
            a.transform.position = new Vector2(screenBounds.x , Random.Range(-screenBounds.y, screenBounds.y));
        }
        else if (random==1)
        {
            GameObject b = Instantiate(asteroidSmall) as GameObject;
            b.transform.position = new Vector2(-screenBounds.x , Random.Range(-screenBounds.y, screenBounds.y));
        }
        else if (random==2)
        {
            GameObject c = Instantiate(asteroidMedium) as GameObject;
            c.transform.position = new Vector2(screenBounds.x , Random.Range(-screenBounds.y, screenBounds.y));
        }
        else if (random==3)
        {
            GameObject d = Instantiate(monster) as GameObject;
            d.transform.position = new Vector2(-screenBounds.x , Random.Range(-screenBounds.y, screenBounds.y));
        }
    }
    IEnumerator asteroidWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
