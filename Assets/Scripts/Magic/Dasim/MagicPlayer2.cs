using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MagicPlayer2 : MonoBehaviour
{
    public AbilityImageManager abilityImageManager;

    public CombatControllerPlayer2 combatControllerPlayer2;



    public bool power1UsedThisTurn = false;
    public bool power2UsedThisTurn = false;

    public bool isPlayer2Turn = true;

    public int power2charge;


    //El pregunta todo el rato si se apreta la tecla
    private void Update()
    {
        if (isPlayer2Turn)
        {
            if (power2charge == 3)
            {
                abilityImageManager.Team2Charge3.enabled = true;
                abilityImageManager.Team2ability2ready.enabled = false;
            }
            if (power2charge <= 2)
            {
                abilityImageManager.Team2Charge3.enabled = false;
                abilityImageManager.Team2Charge2.enabled = true;
                abilityImageManager.Team2ability2ready.enabled = false;
            }
            if (power2charge <= 1)
            {
                abilityImageManager.Team2Charge2.enabled = false;
                abilityImageManager.Team2Charge1.enabled = true;
                abilityImageManager.Team2ability2ready.enabled = false;
            }

            if (power2charge <= 0)
            {

                abilityImageManager.Team2Charge1.enabled = false;
                abilityImageManager.Team2ability2ready.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) && !power1UsedThisTurn)
            {
                SubtractOneUnitP2();
                
                power1UsedThisTurn = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && !power2UsedThisTurn)
            {
                UseSpecialAbility();
                power2UsedThisTurn = false;
            }


        }        //Se pregunta si es turno del jugador, en caso de serlo se activa el power
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

                combatControllerPlayer2.isMagicBanditStrong = true;
            }

        }
        else power2UsedThisTurn = false;
    }


    public void ActiveMagicBanditWeak()
    {

        if (!power1UsedThisTurn)
        {

            combatControllerPlayer2.isMagicBanditWeak = true;


            abilityImageManager.Team2ability1ready.enabled = false;
            abilityImageManager.Team2ChargeA1.enabled = true;

        }
    }











    /////////////////////////////////////////////////////////////
    ////////////////////// MAGIA DRUIDAS  //////////////////////
    ///////////////////////////////////////////////////////////

    //Magia Debil
    public void SubtractOneUnitP2()
    {

        if (!power1UsedThisTurn)
        {

            // Encuentra todas las unidades de Player 2 en la escena
            Unit[] playerUnits = GameObject.FindObjectsOfType<Unit>().Where(unit => unit.CompareTag("Player")).ToArray();

            // Comprueba si hay al menos una unidad de Player 2 en la escena
            if (playerUnits.Length > 0)
            {
                // Encuentra la unidad con el costo más bajo entre las unidades de Player 2

                /////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////
                //(hay que agregar que en caso de quedar todas del mismo coste agarre la de menor unidades)//
                /////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////

                Unit unitWithLowestCost = playerUnits[0];

                foreach (Unit unit in playerUnits)
                {
                    if (unit.GetCost() < unitWithLowestCost.GetCost())
                    {
                        unitWithLowestCost = unit;
                    }
                }

                // Resta 1 unidad a la unidad con el costo más bajo de Player 2
                unitWithLowestCost.SubtractOneUnit();
                abilityImageManager.Team2ability1ready.enabled = false;
                abilityImageManager.Team2ChargeA1.enabled = true;

            }
        }
    }

    //Magia fuerte
    private void UseSpecialAbility()
    {
        if (power2charge <= 0)
        {

            if (!power2UsedThisTurn)
            {
                power2charge = 3;

                // Encuentra todas las unidades de Player 2 en la escena
                Unit[] playerUnits = GameObject.FindObjectsOfType<Unit>().Where(unit => unit.CompareTag("Player")).ToArray();

                if (playerUnits.Length > 0)
                {
                    Unit unitWithHigherCost = playerUnits[0];

                    foreach (Unit unit in playerUnits)
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




                    //turnsUntilChargedPower2 = turnsToChargePower2;
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
