using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public CombatControllerPlayer1 player1;
    public CombatControllerPlayer2 player2;

    public TurnManager turnManager;

    public zone zone;

    [Header("Ejercitos Faccion 1")]
    public GameObject Army1P1;
    public GameObject Army2P1;
    public GameObject Army3P1;

    public GameObject Army1P2;
    public GameObject Army2P2;
    public GameObject Army3P2;

    [Header("Ejercitos Faccion 2")]
    public GameObject Army1P1Ban;
    public GameObject Army2P1Ban;
    public GameObject Army3P1Ban;

    public GameObject Army1P2Ban;
    public GameObject Army2P2Ban;
    public GameObject Army3P2Ban;

    [Header("Magia Bandidos")]
    public GameObject MagicBanditsPlayer1;
    public GameObject MagicBanditsPlayer2;

    [Header("Magia Dasim")]
    public GameObject MagicDasimPlayer1;
    public GameObject MagicDasimPlayer2;

    private bool isStarted = false;


    public static int ArmySelectedP1, ArmySelectedP2;

    private void Awake()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
    }


    private void OnEnable()
    {
        TroopButton.ArmySelectedP1 += SetArmyP1;
        TroopButton.ArmySelectedP2 += SetArmyP2;


    }

    private void OnDisable()
    {
        TroopButton.ArmySelectedP1 -= SetArmyP1;
        TroopButton.ArmySelectedP2 -= SetArmyP2;

    }

    //Si es la primera vez que se ejecuta la escena del juego, carga los ejercitos previamente seleccionados
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 && isStarted == false)
        {


            GetArmyP1();
            GetArmyP2();

            player1.RestartArray();
            player2.RestartArray();

            turnManager.TurnManagment(false);

            isStarted = true;



        }
    }



    public void SetArmyP1(int numArmy)
    {
        ArmySelectedP1 = numArmy; 
    }

    public void GetArmyP1()
    {
        
        switch (ArmySelectedP1)
        {
            //Faccion 1 DASIM
            case 1:
                Army2P1.SetActive(false);
                Army3P1.SetActive(false);
                Army1P1Ban.SetActive(false);
                Army2P1Ban.SetActive(false);
                Army3P1Ban.SetActive(false);

                //Activa Magia
                MagicBanditsPlayer1.SetActive(false);
                //MagicDasimPlayer1.SetActive(true);
                break;

            case 2:
                Army1P1.SetActive(false);
                Army3P1.SetActive(false);
                Army1P1Ban.SetActive(false);
                Army2P1Ban.SetActive(false);
                Army3P1Ban.SetActive(false);

                MagicBanditsPlayer1.SetActive(false);
                //MagicDasimPlayer1.SetActive(true);
                break;

            case 3:
                Army1P1.SetActive(false);
                Army2P1.SetActive(false);
                Army1P1Ban.SetActive(false);
                Army2P1Ban.SetActive(false);
                Army3P1Ban.SetActive(false);

                MagicBanditsPlayer1.SetActive(false);
                //MagicDasimPlayer1.SetActive(true);
                break;

            //Faccion 2
            case 4:
                Army2P1.SetActive(false);
                Army3P1.SetActive(false);
                Army1P1.SetActive(false);
                Army2P1Ban.SetActive(false);
                Army3P1Ban.SetActive(false);

                //MagicBanditsPlayer1.SetActive(true);
                MagicDasimPlayer1.SetActive(false);
                break;

            case 5:
                Army1P1.SetActive(false);
                Army3P1.SetActive(false);
                Army1P1Ban.SetActive(false);
                Army2P1.SetActive(false);
                Army3P1Ban.SetActive(false);

                //MagicBanditsPlayer1.SetActive(true);
                MagicDasimPlayer1.SetActive(false);
                break;

            case 6:
                Army1P1.SetActive(false);
                Army2P1.SetActive(false);
                Army1P1Ban.SetActive(false);
                Army2P1Ban.SetActive(false);
                Army3P1.SetActive(false);

                //MagicBanditsPlayer1.SetActive(true);
                MagicDasimPlayer1.SetActive(false);
                break;

           
        }

    }

    public void SetArmyP2(int numArmy)
    {
        ArmySelectedP2 = numArmy;
    }

    public void GetArmyP2()
    {
        switch (ArmySelectedP2)
        {
            case 1:
                Army2P2.SetActive(false);
                Army3P2.SetActive(false);
                Army1P2Ban.SetActive(false);
                Army2P2Ban.SetActive(false);
                Army3P2Ban.SetActive(false);

                MagicBanditsPlayer2.SetActive(false);
                //MagicDasimPlayer2.SetActive(true);
                break;

            case 2:
                Army1P2.SetActive(false);
                Army3P2.SetActive(false);
                Army1P2Ban.SetActive(false);
                Army2P2Ban.SetActive(false);
                Army3P2Ban.SetActive(false);

                MagicBanditsPlayer2.SetActive(false);
                //MagicDasimPlayer2.SetActive(true);
                break;

            case 3:
                Army1P2.SetActive(false);
                Army2P2.SetActive(false);
                Army1P2Ban.SetActive(false);
                Army2P2Ban.SetActive(false);
                Army3P2Ban.SetActive(false);

                MagicBanditsPlayer2.SetActive(false);
                //MagicDasimPlayer2.SetActive(true);
                break;

            case 4:
                Army2P2.SetActive(false);
                Army3P2.SetActive(false);
                Army1P2.SetActive(false);
                Army2P2Ban.SetActive(false);
                Army3P2Ban.SetActive(false);

                //MagicBanditsPlayer2.SetActive(true);
                MagicDasimPlayer2.SetActive(false);
                break;

            case 5:
                Army1P2.SetActive(false);
                Army3P2.SetActive(false);
                Army1P2Ban.SetActive(false);
                Army2P2.SetActive(false);
                Army3P2Ban.SetActive(false);

                //MagicBanditsPlayer2.SetActive(true);
                MagicDasimPlayer2.SetActive(false);
                break;

            case 6:
                Army1P2.SetActive(false);
                Army2P2.SetActive(false);
                Army1P2Ban.SetActive(false);
                Army2P2Ban.SetActive(false);
                Army3P2.SetActive(false);

                //MagicBanditsPlayer2.SetActive(true);
                MagicDasimPlayer2.SetActive(false);
                break;

        }

    }
   

}
