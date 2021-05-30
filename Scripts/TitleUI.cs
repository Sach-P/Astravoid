using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleUI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public bool hasMouse = true;


    public GameObject startMenuUI;

    public GameObject controlsMenuUI;

    
    public GameObject mouseControls;
    public GameObject noMouseControls;


    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPaused)
            {
                Resume();
            }
          
        }
    }

    public void Resume()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Controls()
    {
        startMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);
        GameIsPaused = false;
    }

    public void Back()
    {
        startMenuUI.SetActive(true);
        controlsMenuUI.SetActive(false);
    }

    public void setMouseTrue(){
        mouseControls.SetActive(true);
        noMouseControls.SetActive(false);
        UI.hasMouse = true;
    }

    public void setMouseFalse(){
        noMouseControls.SetActive(true);
        mouseControls.SetActive(false);
        UI.hasMouse = false;
    }

    public bool getMouseState(){
        return hasMouse;
    }

    public bool getPaused(){
        return GameIsPaused;
    }
}
