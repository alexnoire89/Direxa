using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElSceneManager : MonoBehaviour

{

    public zone zone;

    public CombatControllerPlayer1 player1;
    public CombatControllerPlayer2 player2;



    private void OnEnable()
    {
        CombatControllerPlayer1.OnWarLost += WarWonPlayer2;
        CombatControllerPlayer2.OnWarLost += WarWonPlayer1;


    }

    private void OnDisable()
    {
        CombatControllerPlayer1.OnWarLost -= WarWonPlayer2;
        CombatControllerPlayer2.OnWarLost -= WarWonPlayer1;

    }

  
    private void  WarWonPlayer1()
    {
        SceneManager.LoadScene("victoriap1");
    }

    private void WarWonPlayer2()
    {
        SceneManager.LoadScene("victoriap2");
    }

    private void Update()
    {
        VDcontroller();
    }

    public void VDcontroller()
    {
        if (zone.points1 >= 5)
        {
            SceneManager.LoadScene("victoriap1");
        }

        if (zone.points2 >= 5)
        {
            SceneManager.LoadScene("victoriap2");
        }

        if (zone.points1 >= 5 && zone.points2 >= 5)
        {
            SceneManager.LoadScene("empate");
        }

    }
   
    public void ReturnGame()
    {
        //Escena de seleccion de ejercito
        SceneManager.LoadScene(0);

    }

    public void ExitGame()
    {
        Application.Quit();

    }

}
