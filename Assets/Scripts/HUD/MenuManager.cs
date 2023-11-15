using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    
  public void LoadMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }
  public void LoadTroopSelector()
    {
        SceneManager.LoadScene("TroopSelector");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
