using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class UI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    static public bool hasMouse = true;

    public GameObject mouseControls;
    public GameObject noMouseControls;

    public GameObject pauseMenuUI;

    public GameObject controlsMenuUI;

    public GameObject gameOverUI;
    private bool isGameOver = false;

    public GameObject tabToPause;

    void Start() {
        StartCoroutine(Disable());

    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(3.0f);
        tabToPause.SetActive(false);
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        if(!isGameOver){
            pauseMenuUI.SetActive(true);
            controlsMenuUI.SetActive(false);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        
    }

    public void Controls()
    {
        if(hasMouse){
            mouseControls.SetActive(true);
            noMouseControls.SetActive(false);
        }
        else{
            noMouseControls.SetActive(true);
            mouseControls.SetActive(false);
        }
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGameOver = true;
    }

    public void setMouseTrue(){
        mouseControls.SetActive(true);
        noMouseControls.SetActive(false);
        hasMouse = true;
    }

    public void setMouseFalse(){
        noMouseControls.SetActive(true);
        mouseControls.SetActive(false);
        hasMouse = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu(){
        SceneManager.LoadScene("TitleCard");
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public bool getMouseState(){
        return hasMouse;
    }

    public bool getPaused(){
        return GameIsPaused;
    }
}
