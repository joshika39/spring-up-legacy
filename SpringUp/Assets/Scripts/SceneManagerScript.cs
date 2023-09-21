using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject tutorial1, tutorial2;
    public GameObject menu, finalscore;
    //Start
    void Start()
    {
        
    }

    //Update
    void Update()
    {
        
    }

    //Functions
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene); //!
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Tutorial1()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(true);
    }
    public void Tutorial2()
    {
        tutorial2.SetActive(false);

    }

    public void OpenMenu(bool value)
    {
        menu.SetActive(value);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowScore()
    {
        finalscore.SetActive(true);
    }
    
}
