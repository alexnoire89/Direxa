using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Windows;

public class CombatControllerPlayer2 : MonoBehaviour
{


    [SerializeField] LayerMask p2Mask;
    [SerializeField] float attackRange;
    public ShowText showText;
    private float initialAttackRange;

    private Arch arch;
    private Knight knight;
    private Sword sword;
    private Lance lance;
    private Leva leva;

    public int Player1Select;
    public int Player2Select;

    public TurnManager turnManager;

    public float offsetY;

    public GameObject player1Obj;
    public GameObject[] allChildrenP1;


    public GameObject player2Obj;
    public GameObject[] allChildrenP2;

    public zone zone;
    public zoneb zoneb;
    public zonec zonec;

    public dice dice;

    private bool paintOnlyOnce = true;
    private bool pressed = false;
    public bool isSelected = false;
    private bool isEnemySelected = false;
    private bool selectOnlyOnce = true;
    private bool attackOnlyOnce = true;
    private bool isAttackCycle = false;
    private bool isTurn = false;
    private bool isSelectionCycle = true;

    private float yInput;

    //EVENT
    public static event Action<bool> OnTurnChanged;
    public static event Action<bool> OnPhaseChanged;

    public static event Action OnWarLost;


    public bool isMagicBanditStrong = false;
    public bool isMagicBanditWeak = false;

    private void Start()
    {
        //Tomamos todos las unidades creadas para el Player 2
        RestartArray();
        initialAttackRange = attackRange;
    }

    private void Update()
    {
        yInput = UnityEngine.Input.GetAxisRaw("Vertical");
      

        //Si hay bajas en la partida, limpia el array
        if (allChildrenP2.Length >= 1)
        {
            DeathArray();
        }
     


        //Finalizar seleccion y empezar turno de la unidad
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && isSelectionCycle)
        {
            //Magia fuerte de los bandidos +2 a las unidades misma ronda
            MagicBanditStrong();

            //resetea el ciclo de ataque, el PJ se puede volver a mover
            isAttackCycle = false;

            //resetea bucle de seleccion
            selectOnlyOnce = true;

            //resetea bucle de ataque
            attackOnlyOnce = true;

            showText.HideDices();
      
            allChildrenP2[Player2Select].GetComponent<PlayerController>().InitiateActionsPoints();

            if (isSelected)
            {

                allChildrenP2[Player2Select].GetComponent<PlayerController>().enabled = false;

                //Se pasa array a lista para poder usar la funcion Remove AT
                //Una vez que se borra el objeto, se reconvierte la lista nuevamente sin ese obj
                if (isMagicBanditWeak == false)
                {
                    RemoveObjectFromArray();
                }

                //Se pasa al turno de la unidad del otro player
                Player2Select = 0;
                OnTurnChanged?.Invoke(false);
                isTurn = true;
                isMagicBanditWeak = false;



                if (allChildrenP2.Length <= 0)
                {
                    //Turno del proximo Player
                    RestartArray();


                    //Si es verdadero es turno de player 1
                    OnPhaseChanged?.Invoke(false);
                    isTurn = true;
                    isMagicBanditStrong = false;
                }
                isSelected = false;


            }


            else
            {
                isSelected = true;

            }



        }



        if (!isSelected)
        {
            
                PlayerSelectionCycle();
            
        }


        if (isSelected)
        {
           

            allChildrenP2[Player2Select].GetComponent<PlayerController>().enabled = true;


            ////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////// ATAQUE ///////////////////////////////
            ////////////////////////////////////////////////////////////////////////////


            //Acciona enemigos disponibles en area de ataque
            if (UnityEngine.Input.GetKeyDown(KeyCode.E) && IsEnemiesNear() && selectOnlyOnce)
            {
                //arma un nuevo array con los enemigos en area de ataque
                EnemiesNear();

                //reinicia el puntero del index para que arranque de 0
                Player1Select = 0;

                //Se corta ciclo de seleccion
                isSelectionCycle = false;

                //bool para seleccionar solo una vez
                selectOnlyOnce = false;

                //bool para activar ciclo de seleccion de enemigo
                isEnemySelected = false;

                //bool para manejar el ciclo de ataque
                isAttackCycle = true;


              


            }

            //si estamos en el cyclo de ataque bloqueamos movimiento de player
            if (isAttackCycle)
            {
                allChildrenP2[Player2Select].GetComponent<PlayerController>().enabled = false;
            }
            else allChildrenP2[Player2Select].GetComponent<PlayerController>().enabled = true;


            //Selector de enemigos y banderas
            if (allChildrenP1.Length > 0 && !isEnemySelected && isAttackCycle)
            {

                allChildrenP1[Player1Select].GetComponent<PlayerSelection>().SelectFlag(false);
                AxisDriver2();
                Player1Select = Mathf.Clamp(Player1Select, 0, allChildrenP1.Length - 1);
                allChildrenP1[Player1Select].GetComponent<PlayerSelection>().SelectFlag(true);

            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.T) && isAttackCycle && attackOnlyOnce)
            {
                //limpia selector de enemigo
                allChildrenP1[Player1Select].GetComponent<PlayerSelection>().SelectFlag(false);

                //bool para cortar el ciclo del selector
                isEnemySelected = true;

                //bool para atacar solo una vez
                attackOnlyOnce = false;

                //Activa ciclos de dados o banderas segun corresponda
                DicesCycle();
                ZoneCycle();

                //al terminar de atacar se resetea todo el turno
                isTurn = true;

                //Se reactiva ciclo de seleccion para proximo turno
                isSelectionCycle = true;
            }

         

        }

        //Limpia el array si hay unidades muertas
         DeathArray();
        
    }

    private void MagicBanditStrong()
    {
        if (isMagicBanditStrong)
        {
            //Preguntar que clase es para accionar puntos de movimiento
            if (allChildrenP2[Player2Select].TryGetComponent<Sword>(out sword))
            {
                sword.GetComponent<Sword>().RestartActionPoints(4);
            }

            if (allChildrenP2[Player2Select].TryGetComponent<Arch>(out arch))
            {
                arch.GetComponent<Arch>().RestartActionPoints(4);
            }

            if (allChildrenP2[Player2Select].TryGetComponent<Lance>(out lance))
            {
                lance.GetComponent<Lance>().RestartActionPoints(4);
            }

            if (allChildrenP2[Player2Select].TryGetComponent<Knight>(out knight))
            {
                knight.GetComponent<Knight>().RestartActionPoints(5);
            }

            if (allChildrenP2[Player2Select].TryGetComponent<Leva>(out leva))
            {
                leva.GetComponent<Leva>().RestartActionPoints(4);
            }

        }
        else
        {
            //Preguntar que clase es para accionar puntos de movimiento
            if (allChildrenP2[Player2Select].TryGetComponent<Sword>(out sword))
            {
                sword.GetComponent<Sword>().RestartActionPoints();
            }

            if (allChildrenP2[Player2Select].TryGetComponent<Arch>(out arch))
            {
                arch.GetComponent<Arch>().RestartActionPoints();
            }

            if (allChildrenP2[Player2Select].TryGetComponent<Lance>(out lance))
            {
                lance.GetComponent<Lance>().RestartActionPoints();
            }

            if (allChildrenP2[Player2Select].TryGetComponent<Knight>(out knight))
            {
                knight.GetComponent<Knight>().RestartActionPoints();
            }

            if (allChildrenP2[Player2Select].TryGetComponent<Leva>(out leva))
            {
                leva.GetComponent<Leva>().RestartActionPoints();
            }

        }
    }

    private void ZoneCycle()
    {

        if (allChildrenP1[Player1Select].GetComponent<zone>())
        {

            zone.capturep1 = false;
            zone.capturep2 = true;
            //Debug.Log("punto2");



        }

        if (allChildrenP1[Player1Select].GetComponent<zoneb>())
        {

            zoneb.captureBp1 = false;
            zoneb.captureBp2 = true;
            //Debug.Log("punto2");


        }
        if (allChildrenP1[Player1Select].GetComponent<zonec>())
        {

            zonec.captureCp1 = false;
            zonec.captureCp2 = true;
            //Debug.Log("punto2");

        }
    }
    private void DicesCycle()
    {

        if (allChildrenP1[Player1Select].GetComponent<Sword>())
        {
            dice.LanzarDado();
            VentajasDesventajas();
            dice.CompararResultados(dice.dado1P1, dice.dado2P1, dice.dado3P1, dice.dado4P2, dice.dado5P2, dice.dado6P2);

            if (dice.comp1 == false)
            {

                allChildrenP1[Player1Select].GetComponent<Sword>().SubUnitsNumber(1);
                //Debug.Log("Lo lograste pibe");
            }

            if (dice.comp2 == false)
            {

                allChildrenP1[Player1Select].GetComponent<Sword>().SubUnitsNumber(1);
                //Debug.Log("Lo lograste pibe x2");
            }

            if (dice.comp3 == false)
            {
                allChildrenP1[Player1Select].GetComponent<Sword>().SubUnitsNumber(1);
                //Debug.Log("lo lograste pibex3");
            }

        }

        if (allChildrenP1[Player1Select].GetComponent<Lance>())
        {
            dice.LanzarDado();
            VentajasDesventajas();
            dice.CompararResultados(dice.dado1P1, dice.dado2P1, dice.dado3P1, dice.dado4P2, dice.dado5P2, dice.dado6P2);

            if (dice.comp1 == false)
            {

                allChildrenP1[Player1Select].GetComponent<Lance>().SubUnitsNumber(1);
                //Debug.Log("Lo lograste pibe");
            }

            if (dice.comp2 == false)
            {

                allChildrenP1[Player1Select].GetComponent<Lance>().SubUnitsNumber(1);
                //Debug.Log("Lo lograste pibe x2");
            }

            if (dice.comp3 == false)
            {
                allChildrenP1[Player1Select].GetComponent<Lance>().SubUnitsNumber(1);
                //Debug.Log("lo lograste pibex3");
            }

        }

        if (allChildrenP1[Player1Select].GetComponent<Arch>())
        {
            dice.LanzarDado();
            VentajasDesventajas();
            dice.CompararResultados(dice.dado1P1, dice.dado2P1, dice.dado3P1, dice.dado4P2, dice.dado5P2, dice.dado6P2);
            if (dice.comp1 == false)
            {

                allChildrenP1[Player1Select].GetComponent<Arch>().SubUnitsNumber(1);
                //Debug.Log("Lo lograste pibe");
            }

            if (dice.comp2 == false)
            {

                allChildrenP1[Player1Select].GetComponent<Arch>().SubUnitsNumber(1);
                //Debug.Log("Lo lograste pibe x2");
            }

            if (dice.comp3 == false)
            {
                allChildrenP1[Player1Select].GetComponent<Arch>().SubUnitsNumber(1);
                //Debug.Log("lo lograste pibex3");
            }

        }

        if (allChildrenP1[Player1Select].GetComponent<Knight>())
        {
            dice.LanzarDado();
            VentajasDesventajas();
            dice.CompararResultados(dice.dado1P1, dice.dado2P1, dice.dado3P1, dice.dado4P2, dice.dado5P2, dice.dado6P2);
            if (dice.comp1 == false)
            {

                allChildrenP1[Player1Select].GetComponent<Knight>().SubUnitsNumber(1);
                //Debug.Log("Lo lograste pibe");
            }

            if (dice.comp2 == false)
            {

                allChildrenP1[Player1Select].GetComponent<Knight>().SubUnitsNumber(1);
                //Debug.Log("Lo lograste pibe x2");
            }

            if (dice.comp3 == false)
            {
                allChildrenP1[Player1Select].GetComponent<Knight>().SubUnitsNumber(1);
                //Debug.Log("lo lograste pibex3");
            }

        }

        if (allChildrenP1[Player1Select].GetComponent<Leva>())
        {
            dice.LanzarDado();
            VentajasDesventajas();
            dice.CompararResultados(dice.dado1P1, dice.dado2P1, dice.dado3P1, dice.dado4P2, dice.dado5P2, dice.dado6P2);
            if (dice.comp1 == true)
            {

                allChildrenP1[Player1Select].GetComponent<Leva>().SubUnitsNumber(1);
                //Debug.Log("Lo lograste pibe");
            }

            if (dice.comp2 == true)
            {

                allChildrenP1[Player1Select].GetComponent<Leva>().SubUnitsNumber(1);
                //Debug.Log("Lo lograste pibe x2");
            }

            if (dice.comp3 == true)
            {
                allChildrenP1[Player1Select].GetComponent<Leva>().SubUnitsNumber(1);
                //Debug.Log("lo lograste pibex3");
            }


        }
    }
    private void PlayerSelectionCycle()


    {

        if (isMagicBanditStrong == false)
        {

            if (allChildrenP2[Player2Select].TryGetComponent<Knight>(out knight))
            {
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SetPositionPlayerKnight(allChildrenP2[Player2Select].transform.position);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectKnight(false);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectKnightPlus(false);
            }

            //Consulta si es Caballeria ya que es la unica unidad con movimiento extra, en caso que no sea se ejecuta para el resto de unidades
            //Si es apaga el selector de personaje, Tambien en este bucle guardamos la posicion inicial del player
            //para que se pinte en pantalla los posibles movimientos
            //if (allChildrenP1[Player1Select].GetComponent<Knight>())
            //{
            //    allChildrenP1[Player1Select].GetComponent<PlayerSelection>().SetPositionPlayerKnight(allChildrenP1[Player1Select].transform.position);
            //    allChildrenP1[Player1Select].GetComponent<PlayerSelection>().SelectKnight(false);
            //}

            else
            {
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SetPositionPlayer(allChildrenP2[Player2Select].transform.position);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().Select(false);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectPlus(false);
            }


            //Bucle para controlador ya que AxisRaw no tiene funciones de getkeydown
            //y necesitamos que se aprieta solo una vez por vez, para el selector
            //Dentro se encuentra el flag paintOnlyOnce para el selector de hexagonos

            AxisDriver();

            //Calcula el movimiento del selector entre el primer objeto y el ultimo
            Player2Select = Mathf.Clamp(Player2Select, 0, allChildrenP2.Length - 1);

            //Se vuelve a activar, esto da la animacion de ir pasando encima de cada player************


            if (allChildrenP2[Player2Select].GetComponent<Knight>())
            {
                //Se usa un flag para que solo se ejecute una vez el pintado de hexas
                //Esto es porque a veces colisionan hexas en objetos limites y necesitamos que se carguen de nuevo
                if (!paintOnlyOnce)
                {
                    allChildrenP2[Player2Select].GetComponent<PlayerSelection>().PaintHexasKnight();
                    paintOnlyOnce = true;
                }
                else allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectKnight(true);

            }

            else
            {

                if (!paintOnlyOnce)
                {
                    allChildrenP2[Player2Select].GetComponent<PlayerSelection>().PaintHexas();
                    paintOnlyOnce = true;
                }
                else allChildrenP2[Player2Select].GetComponent<PlayerSelection>().Select(true);

            }

            //Ciclo que se activa cuando se cambia de turno para resetear el selector y dejarlo invisible
            if (isTurn)
            {
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().PaintHexasKnight();
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().PaintHexas();
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().Select(false);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectKnight(false);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().PaintHexasKnightPlus();
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().PaintHexasPlus();
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectPlus(false);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectKnightPlus(false);


                isTurn = false;
            }

        }





        else
        {
            if (allChildrenP2[Player2Select].TryGetComponent<Knight>(out knight))
            {
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SetPositionPlayerKnightPlus(allChildrenP2[Player2Select].transform.position);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectKnightPlus(false);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectKnight(false);

            }

            //Consulta si es Caballeria ya que es la unica unidad con movimiento extra, en caso que no sea se ejecuta para el resto de unidades
            //Si es apaga el selector de personaje, Tambien en este bucle guardamos la posicion inicial del player
            //para que se pinte en pantalla los posibles movimientos
            //if (allChildrenP1[Player1Select].GetComponent<Knight>())
            //{
            //    allChildrenP1[Player1Select].GetComponent<PlayerSelection>().SetPositionPlayerKnight(allChildrenP1[Player1Select].transform.position);
            //    allChildrenP1[Player1Select].GetComponent<PlayerSelection>().SelectKnight(false);
            //}

            else
            {
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SetPositionPlayerPlus(allChildrenP2[Player2Select].transform.position);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectPlus(false);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().Select(false);
            }


            //Bucle para controlador ya que AxisRaw no tiene funciones de getkeydown
            //y necesitamos que se aprieta solo una vez por vez, para el selector
            //Dentro se encuentra el flag paintOnlyOnce para el selector de hexagonos

            AxisDriver();

            //Calcula el movimiento del selector entre el primer objeto y el ultimo
            Player2Select = Mathf.Clamp(Player2Select, 0, allChildrenP2.Length - 1);

            //Se vuelve a activar, esto da la animacion de ir pasando encima de cada player************


            if (allChildrenP2[Player2Select].GetComponent<Knight>())
            {
                //Se usa un flag para que solo se ejecute una vez el pintado de hexas
                //Esto es porque a veces colisionan hexas en objetos limites y necesitamos que se carguen de nuevo
                if (!paintOnlyOnce)
                {
                    allChildrenP2[Player2Select].GetComponent<PlayerSelection>().PaintHexasKnightPlus();
                    paintOnlyOnce = true;
                }
                else allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectKnightPlus(true);

            }

            else
            {

                if (!paintOnlyOnce)
                {
                    allChildrenP2[Player2Select].GetComponent<PlayerSelection>().PaintHexasPlus();
                    paintOnlyOnce = true;
                }
                else allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectPlus(true);

            }

            //Ciclo que se activa cuando se cambia de turno para resetear el selector y dejarlo invisible
            if (isTurn)
            {
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().PaintHexasKnightPlus();
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().PaintHexasPlus();
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectPlus(false);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectKnightPlus(false);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().PaintHexasKnight();
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().PaintHexas();
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().Select(false);
                allChildrenP2[Player2Select].GetComponent<PlayerSelection>().SelectKnight(false);


                isTurn = false;
            }

        }

    }
    private void DeathArray()
    {
        List<GameObject> activeChildrenList = new List<GameObject>();

        if (allChildrenP1 != null)
        {
            foreach (GameObject child in allChildrenP2)
            {
                if (child.activeSelf)
                {
                    activeChildrenList.Add(child);
                }
            }


            if (activeChildrenList.Count > 0)
            {
                // Si hay al menos un objeto activo, convierte la lista a un arreglo
                allChildrenP2 = activeChildrenList.ToArray();
            }
            else
            {
                Debug.Log("Victoria Player 1");
                OnWarLost?.Invoke();
            }
        }
        else
        {
            // En caso de que no haya objetos activos
            allChildrenP2 = new GameObject[0];
           
        }
     

    }
    private void EnemiesNear()
    {

        Vector3 unitPosition = new Vector3(allChildrenP2[Player2Select].transform.position.x, allChildrenP2[Player2Select].transform.position.y - offsetY, 0);

        if (allChildrenP2[Player2Select].TryGetComponent<Arch>(out arch))
        {
            attackRange = arch.GetComponent<Arch>().GetAttackRange();
        }
        else attackRange = initialAttackRange;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(unitPosition, attackRange, p2Mask);

        List<GameObject> list = new List<GameObject>(allChildrenP1);

        //Se limpia el array
        list.Clear();
        allChildrenP1 = list.ToArray();

        foreach (Collider2D c in colliders)
        {
            list.Add(c.transform.gameObject);

        }

        allChildrenP1 = list.ToArray();


    }
    private bool IsEnemiesNear()
    {

        Vector3 unitPosition = new Vector3(allChildrenP2[Player2Select].transform.position.x, allChildrenP2[Player2Select].transform.position.y - offsetY, 0);

        if (allChildrenP2[Player2Select].TryGetComponent<Arch>(out arch))
        {
            attackRange = arch.GetComponent<Arch>().GetAttackRange();
        }
        else attackRange = initialAttackRange;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(unitPosition, attackRange, p2Mask);

        if (colliders.Length > 0)
        {

            return true;
        }
        else return false;

    }
    public void RestartArray()
    {

        // Encuentra la carpeta hija activa
        Transform activeChild = null;
        foreach (Transform child in player2Obj.transform)
        {
            if (child.gameObject.activeSelf)
            {
                activeChild = child;
                break;
            }
        }

        if (activeChild != null)
        {
            // Luego, lee todos los objetos hijos de la carpeta activa
            allChildrenP2 = new GameObject[activeChild.childCount];

            for (int i = 0; i < activeChild.childCount; i++)
            {
                allChildrenP2[i] = activeChild.GetChild(i).gameObject;
            }
        }
        else
        {
            // En caso de que no haya una carpeta hija activa, inicializa allChildrenP1 como un arreglo vacío
            allChildrenP2 = new GameObject[0];
        }

        Player2Select = 0;
    }
    private void RemoveObjectFromArray()
    {
        if (allChildrenP2 != null)
        {
            List<GameObject> removeList = new List<GameObject>(allChildrenP2);
            removeList.RemoveAt(removeList.IndexOf(allChildrenP2[Player2Select]));
            allChildrenP2 = removeList.ToArray();
        }
        else
        {
            // En caso de que no haya una carpeta hija activa, inicializa allChildrenP1 como un arreglo vacío
            allChildrenP2 = new GameObject[0];
        }

        Player2Select = 0;
    }
    private void AxisDriver()
    {
        if (pressed == false)
        {
            if (yInput != 0f)
            {

                //Mueve el selector para Abajo
                if (yInput == 1) Player2Select--; paintOnlyOnce = false;

                //Arriba
                if (yInput == -1) Player2Select++; paintOnlyOnce = false;

                pressed = true;

            }

        }
        if (pressed == true)
        {
            if (yInput == 0f)
            {

                pressed = false;

            }

        }
    }
    private void AxisDriver2()
    {
        if (pressed == false)
        {
            if (yInput != 0f)
            {

                //Mueve el selector para Abajo
                if (yInput == -1) Player1Select--;

                //Arrib
                if (yInput == 1) Player1Select++;

                pressed = true;

            }

        }
        if (pressed == true)
        {
            if (yInput == 0f)
            {

                pressed = false;

            }

        }
    }
    private void VentajasDesventajas()
    {
        //Se aplican Ventajas y Desventajas en el ataque segun comparacion de unidades
        /*
        Sword:
        Ven: LANCE LEVAS
        Des: KNIGHT

        Lance:
        Ven: KNIGHT LEVAS
        Des: SWORD

        Knight:
        Ven: SWORD LEVAS
        Des: LANCE

        Levas:
        Ven: -
        Des: Todos

        Arch:
        Ven: LEVAS
        Des: -
        */

        //Espadachines
        if (allChildrenP2[Player2Select].GetComponent<Sword>())
        {
            //VENTAJA
            if (allChildrenP1[Player1Select].GetComponent<Lance>())
            {
                dice.dado4P2 += 2;
                dice.dado5P2 += 2;
                dice.dado6P2 += 2;


            }
            if (allChildrenP1[Player1Select].GetComponent<Leva>())
            {
                dice.dado4P2 += 2;
                dice.dado5P2 += 2;
                dice.dado6P2 += 2;
            }

            //DESVENTAJA
            if (allChildrenP1[Player1Select].GetComponent<Knight>())
            {
                dice.dado4P2 -= 2;
                dice.dado5P2 -= 2;
                dice.dado6P2 -= 2;

                if (dice.dado4P2 < 1) dice.dado4P2 = 1;
                if (dice.dado5P2 < 1) dice.dado5P2 = 1;
                if (dice.dado6P2 < 1) dice.dado6P2 = 1;

            }


        }

        //Lanceros
        if (allChildrenP2[Player2Select].GetComponent<Lance>())
        {
            //Ventaja
            if (allChildrenP1[Player1Select].GetComponent<Knight>())
            {
                dice.dado4P2 += 2;
                dice.dado5P2 += 2;
                dice.dado6P2 += 2;
            }

            if (allChildrenP1[Player1Select].GetComponent<Leva>())
            {
                dice.dado4P2 += 2;
                dice.dado5P2 += 2;
                dice.dado6P2 += 2;
            }

            //Desventaja
            if (allChildrenP1[Player1Select].GetComponent<Sword>())
            {
                dice.dado4P2 -= 2;
                dice.dado5P2 -= 2;
                dice.dado6P2 -= 2;

                if (dice.dado4P2 < 1) dice.dado4P2 = 1;
                if (dice.dado5P2 < 1) dice.dado5P2 = 1;
                if (dice.dado6P2 < 1) dice.dado6P2 = 1;

            }


        }

        //Caballeria
        if (allChildrenP2[Player2Select].GetComponent<Knight>())
        {
            //Ventaja
            if (allChildrenP1[Player1Select].GetComponent<Sword>())
            {
                dice.dado4P2 += 2;
                dice.dado5P2 += 2;
                dice.dado6P2 += 2;
            }
            if (allChildrenP1[Player1Select].GetComponent<Leva>())
            {
                dice.dado4P2 += 2;
                dice.dado5P2 += 2;
                dice.dado6P2 += 2;
            }

            //Desventaja
            if (allChildrenP1[Player1Select].GetComponent<Lance>())
            {
                dice.dado4P2 -= 2;
                dice.dado5P2 -= 2;
                dice.dado6P2 -= 2;

                if (dice.dado4P2 < 1) dice.dado4P2 = 1;
                if (dice.dado5P2 < 1) dice.dado5P2 = 1;
                if (dice.dado6P2 < 1) dice.dado6P2 = 1;
            }
        }

        //Levas
        if (allChildrenP2[Player2Select].GetComponent<Leva>())
        {
            //Desventaja contra todos
            dice.dado4P2 -= 2;
            dice.dado5P2 -= 2;
            dice.dado6P2 -= 2;

            if (dice.dado4P2 < 1) dice.dado4P2 = 1;
            if (dice.dado5P2 < 1) dice.dado5P2 = 1;
            if (dice.dado6P2 < 1) dice.dado6P2 = 1;
        }

        //Arqueros
        if (allChildrenP2[Player2Select].GetComponent<Arch>())
        {
            //Ventaja
            if (allChildrenP1[Player1Select].GetComponent<Leva>())
            {
                dice.dado4P2 += 2;
                dice.dado5P2 += 2;
                dice.dado6P2 += 2;
            }
        }
    }

}
