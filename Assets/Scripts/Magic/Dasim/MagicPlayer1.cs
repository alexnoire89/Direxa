using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MagicPlayer1 : MonoBehaviour
{
    public AbilityImageManager abilityImageManager;

    public CombatControllerPlayer1 combatControllerPlayer1;


    public bool power1UsedThisTurn = false;
    public bool power2UsedThisTurn = false;

    public bool isPlayer1Turn = true;

    public int power2charge;



    //El pregunta todo el rato si se apreta la tecla
    private void Update()
    {


        //Se pregunta si es turno del jugador, en caso de serlo se activa el power
        if (isPlayer1Turn)

        {
            if (power2charge == 3)
            {
                abilityImageManager.Team1Charge3.enabled = true;
                abilityImageManager.Team1ability2ready.enabled = false;
            }
            if (power2charge <= 2)
            {
                abilityImageManager.Team1Charge3.enabled = false;
                abilityImageManager.Team1Charge2.enabled = true;
                abilityImageManager.Team1ability2ready.enabled = false;
            }
            if (power2charge <= 1)
            {
                abilityImageManager.Team1Charge2.enabled = false;
                abilityImageManager.Team1Charge1.enabled = true;
                abilityImageManager.Team1ability2ready.enabled = false;
            }

            if (power2charge <= 0)
            {

                abilityImageManager.Team1Charge1.enabled = false;
                abilityImageManager.Team1ability2ready.enabled = true;
            }


            if (Input.GetKeyDown(KeyCode.Alpha1) && !power1UsedThisTurn)
            {
                SubtractOneUnitP1();
                power1UsedThisTurn = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && !power2UsedThisTurn)
            {
                UseSpecialAbility();
                power2UsedThisTurn = false;
            }
        }

    }













    /////////////////////////////////////////////////////////////
    ////////////////////// MAGIA BANDIDOS  /////////////////////
    ///////////////////////////////////////////////////////////

    private void ActiveMagicBanditStrong()
    {


        if (power2charge <= 0)
        {

            if (!power2UsedThisTurn)
            {
                power2charge = 3;

                combatControllerPlayer1.isMagicBanditStrong = true;
            }

        }
        else power2UsedThisTurn = false;
    }



    public void ActiveMagicBanditWeak()
    {

        if (!power1UsedThisTurn)
        {

            combatControllerPlayer1.isMagicBanditWeak = true;


            abilityImageManager.Team1ability1ready.enabled = false;
            abilityImageManager.Team1ChargeA1.enabled = true;

        }
    }











    /////////////////////////////////////////////////////////////
    ////////////////////// MAGIA DRUIDAS  //////////////////////
    ///////////////////////////////////////////////////////////


    public void SubtractOneUnitP1()
    {

        if (!power1UsedThisTurn)
        {

            // Encuentra todas las unidades de Player 2 en la escena
            Unit[] player2Units = GameObject.FindObjectsOfType<Unit>().Where(unit => unit.CompareTag("Player2")).ToArray();

            // Comprueba si hay al menos una unidad de Player 2 en la escena
            if (player2Units.Length > 0)
            {
                // Encuentra la unidad con el costo más bajo entre las unidades de Player 2

                /////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////
                //(hay que agregar que en caso de quedar todas del mismo coste agarre la de menor unidades)//
                /////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////

                Unit unitWithLowestCost = player2Units[0];

                foreach (Unit unit in player2Units)
                {
                    if (unit.GetCost() < unitWithLowestCost.GetCost())
                    {
                        unitWithLowestCost = unit;
                    }
                }

                // Resta 1 unidad a la unidad con el costo más bajo de Player 2
                unitWithLowestCost.SubtractOneUnit();
                abilityImageManager.Team1ability1ready.enabled = false;
                abilityImageManager.Team1ChargeA1.enabled = true;
            }
        }
    }

    private void UseSpecialAbility()
    {
        if (power2charge <= 0)
        {


            if (!power2UsedThisTurn)
            {
                //abilityImageManager.Team1ability2ready.enabled = false ;
                power2charge = 3;

                // Encuentra todas las unidades de Player 2 en la escena
                Unit[] player2Units = GameObject.FindObjectsOfType<Unit>().Where(unit => unit.CompareTag("Player2")).ToArray();

                if (player2Units.Length > 0)
                {
                    Unit unitWithHigherCost = player2Units[0];

                    foreach (Unit unit in player2Units)
                    {
                        if (unit.GetCost() > unitWithHigherCost.GetCost())
                        {
                            unitWithHigherCost = unit;
                        }
                    }

                    // Resta 3 unidades a la unidad con el costo más bajo de Player 2
                    for (int i = 0; i < 3; i++)
                    {
                        unitWithHigherCost.SubtractOneUnit();
                    }





                }
            }

        }
        else power2UsedThisTurn = false;
    }

    public void chargepower()
    {
        power2charge--;
    }

}
