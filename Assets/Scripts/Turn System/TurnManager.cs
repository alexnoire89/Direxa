using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    public AbilityImageManager abilityImageManager;
    public Powerrrr powerP2;
    public PowersP1 powerP1;
    public MagicPlayer1 magicPlayer1;
    public MagicPlayer2 magicPlayer2;


    public GameObject p1CombatController;
    public GameObject p2CombatController;

    public PlayerController playerController;

    public bool vuelta = false;
    public bool vuelta2= false;

    public TMP_Text phaseNum;
    public int phasePas = 0;

    public zone zone;
    public zoneb zoneb;
    public zonec zonec;

    public Sword sword;
    public Arch arch;
    public Lance lance;
    public Knight knight;
    public Leva leva;


    //Flags estaticos para manejar los turnos en cada fase
    private static bool isPhaseP1= false;
    private static bool isPhaseP2= false;

    private void Start()
    {
        TurnManagment(false);
      
    }



    private void Update()
    {

      phaseNum.text = phasePas.ToString();

        if (vuelta == true && vuelta2 == true)
        {
            phasePas++;
            // puntos para el player 1
            if (zone.capturep1 == true)
            {
                zone.points1++;
                //Debug.Log("punto1");
            }

            if( zoneb.captureBp1 == true){
                zone.points1++;
            }

            if(zonec.captureCp1 == true){
                zone.points1++;
            }



            //puntos para el player 2
            if (zone.capturep2 == true)
            {
                zone.points2++;
                //Debug.Log("punto2");
            }
            
            if(zoneb.captureBp2 == true){
                zone.points2++;
            }

            if(zonec.captureCp2 == true){
                zone.points2++;
            }

            //reinicio para las vueltas
            vuelta2 = false;
            vuelta =false;





}
    }


    private void OnEnable()
    {
        CombatControllerPlayer1.OnTurnChanged += TurnManagment;
        CombatControllerPlayer2.OnTurnChanged += TurnManagment;

        CombatControllerPlayer1.OnPhaseChanged += PhaseManagment;
        CombatControllerPlayer2.OnPhaseChanged += PhaseManagment;


    }

    private void OnDisable()
    {
        CombatControllerPlayer1.OnTurnChanged -= TurnManagment;
        CombatControllerPlayer2.OnTurnChanged -= TurnManagment;

        CombatControllerPlayer1.OnPhaseChanged -= PhaseManagment;
        CombatControllerPlayer2.OnPhaseChanged -= PhaseManagment;
    }


    public void PhaseManagment(bool playerPhase)
    {
        if (playerPhase)
        {
            isPhaseP2 = true;

            //Comienza FASE Player 2
            abilityImageManager.Team2ChargeA1.enabled = false;
            abilityImageManager.Team2ability1ready.enabled = true;

            if (powerP2.gameObject.activeSelf && powerP1.gameObject.activeSelf)
            {
                powerP2.power1UsedThisTurn = false;
                powerP2.chargepower();

                powerP1.enabled = false;
                powerP2.enabled = true;
            }
            else if(powerP2.gameObject.activeSelf && magicPlayer1.gameObject.activeSelf)
            {
                powerP2.power1UsedThisTurn = false;
                powerP2.chargepower();

                magicPlayer1.enabled = false;
                powerP2.enabled = true;
            }
            else if (magicPlayer2.gameObject.activeSelf && magicPlayer1.gameObject.activeSelf)
            {
                magicPlayer2.power1UsedThisTurn = false;
                magicPlayer2.chargepower();

                magicPlayer1.enabled = false;
                magicPlayer2.enabled = true;
            }
            else if (magicPlayer2.gameObject.activeSelf && powerP1.gameObject.activeSelf)
            {
                magicPlayer2.power1UsedThisTurn = false;
                magicPlayer2.chargepower();

                powerP1.enabled = false;
                magicPlayer2.enabled = true;
            }



            p1CombatController.GetComponent<CombatControllerPlayer1>().enabled = false;
            p2CombatController.GetComponent<CombatControllerPlayer2>().enabled = true;

   

            //comprueba que haya terminado la fase del player 2
            if (p2CombatController.GetComponent <CombatControllerPlayer2>().allChildrenP2.Length == p2CombatController.GetComponent<CombatControllerPlayer2>().allChildrenP2.Length )
            {
                //Debug.Log("Fin fase p2" + p2CombatController.GetComponent<CombatControllerPlayer2>().allChildrenP2.Length);
                vuelta2 = true;
                //isMagicBanditStrongP2 = false;
            }
            
        }

        else
        {
            isPhaseP1 = true;


            //Comienza FASE Player 1
            abilityImageManager.Team1ChargeA1.enabled = false;
            abilityImageManager.Team1ability1ready.enabled = true;

            //powerP1.power1UsedThisTurn = false;
            //powerP1.chargepower();
            //powerP1.enabled = true;

            //powerP2.enabled = false;

            if (powerP1.gameObject.activeSelf && powerP2.gameObject.activeSelf)
            {
                powerP1.power1UsedThisTurn = false;
                powerP1.chargepower();
                powerP1.enabled = true;
                powerP2.enabled = false;
            }
            else if (powerP1.gameObject.activeSelf && magicPlayer2.gameObject.activeSelf)
            {
                powerP1.power1UsedThisTurn = false;
                powerP1.chargepower();
                powerP1.enabled = true;
                magicPlayer2.enabled = false;
            }
            else if (magicPlayer1.gameObject.activeSelf && magicPlayer2.gameObject.activeSelf)
            {
                magicPlayer1.power1UsedThisTurn = false;
                magicPlayer1.chargepower();
                magicPlayer1.enabled = true;
                magicPlayer2.enabled = false;
            }
            else if (magicPlayer1.gameObject.activeSelf && powerP2.gameObject.activeSelf)
            {
                magicPlayer1.power1UsedThisTurn = false;
                magicPlayer1.chargepower();
                magicPlayer1.enabled = true;
                powerP2.enabled = false;
            }


            p2CombatController.GetComponent<CombatControllerPlayer2>().enabled = false;
            p1CombatController.GetComponent<CombatControllerPlayer1>().enabled = true;


       


            //comprueba que haya terminado la fase del player 1
            if (p1CombatController.GetComponent<CombatControllerPlayer1>().allChildrenP1.Length == p1CombatController.GetComponent<CombatControllerPlayer1>().allChildrenP1.Length)
            {
                //Debug.Log("Fin fase p1");
                vuelta = true;
                //isMagicBanditStrongP1 = false;
            }
            
        }

        if(isPhaseP2 && isPhaseP1)
        {
            isPhaseP2 = false;
            isPhaseP1 = false;
        }


    }

   
   
public void TurnManagment(bool playerTurn)
    {
        if(isPhaseP1 == false)
        {
            if (playerTurn)
            {

                //Se desactiva el combat controller de un player para darselo a otro y viceversa
                //Se activa y desactivan los poderes, al igual q se modifica el bool para q solo se pueda usar 1 vez por turno
                //powerP1.enabled = false;
                //powerP2.enabled = true;

                if (powerP2.gameObject.activeSelf && powerP1.gameObject.activeSelf)
                {
                    powerP1.enabled = false;
                    powerP2.enabled = true;
                }
                else if (powerP2.gameObject.activeSelf && magicPlayer1.gameObject.activeSelf)
                {
                    magicPlayer1.enabled = false;
                    powerP2.enabled = true;
                }
                else if (magicPlayer2.gameObject.activeSelf && magicPlayer1.gameObject.activeSelf)
                {
                    magicPlayer1.enabled = false;
                    magicPlayer2.enabled = true;
                }
                else if (magicPlayer2.gameObject.activeSelf && powerP1.gameObject.activeSelf)
                {
                    powerP1.enabled = false;
                    magicPlayer2.enabled = true;
                }




                p1CombatController.GetComponent<CombatControllerPlayer1>().enabled = false;
                p2CombatController.GetComponent<CombatControllerPlayer2>().enabled = true;





            }
        }

        if (isPhaseP2 == false)
        {

            if (playerTurn == false)
            {
                //powerP1.enabled = true;
                //powerP2.enabled = false;

                if (powerP1.gameObject.activeSelf && powerP2.gameObject.activeSelf)
                {
                    powerP1.enabled = true;
                    powerP2.enabled = false;
                }
                else if (powerP1.gameObject.activeSelf && magicPlayer2.gameObject.activeSelf)
                {
                    powerP1.enabled = true;
                    magicPlayer2.enabled = false;
                }
                else if (magicPlayer1.gameObject.activeSelf && magicPlayer2.gameObject.activeSelf)
                {
                    magicPlayer1.enabled = true;
                    magicPlayer2.enabled = false;
                }
                else if (magicPlayer1.gameObject.activeSelf && powerP2.gameObject.activeSelf)
                {
                    magicPlayer1.enabled = true;
                    powerP2.enabled = false;
                }




                p2CombatController.GetComponent<CombatControllerPlayer2>().enabled = false;
                p1CombatController.GetComponent<CombatControllerPlayer1>().enabled = true;





            }

        }
    }

  
}
