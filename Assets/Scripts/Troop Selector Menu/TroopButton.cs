using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TroopButton : MonoBehaviour
{

    public GameManager gameManager;

    //private Animator animator;


    [Header("Selector Sprites")]
    //Sprites Rombos Selectores
    public GameObject SpriteLevaP1;
    public GameObject SpriteTrinidadP1;
    public GameObject SpriteAntiP1;

    public GameObject SpriteLevaP2;
    public GameObject SpriteTrinidadP2;
    public GameObject SpriteAntiP2;

    [Header("Selector Sprites Bandidos")]
    //Sprites Rombos Selectores
    public GameObject SpriteLevaP1Ban;
    public GameObject SpriteTrinidadP1Ban;
    public GameObject SpriteAntiP1Ban;

    public GameObject SpriteLevaP2Ban;
    public GameObject SpriteTrinidadP2Ban;
    public GameObject SpriteAntiP2Ban;

    [Header("Characters Sprites")]
    //Sprites Personajes en Pantalla
    public GameObject arch1;
    public GameObject knight1;
    public GameObject sword1;
    public GameObject leva1;
    public GameObject lance1;

    public GameObject arch2;
    public GameObject knight2;
    public GameObject sword2;
    public GameObject leva2;
    public GameObject lance2;

    [Header("Characters Sprites Bandidos")]
    //Sprites Personajes en Pantalla
    public GameObject arch1Ban;
    public GameObject knight1Ban;
    public GameObject sword1Ban;
    public GameObject leva1Ban;
    public GameObject lance1Ban;

    public GameObject arch2Ban;
    public GameObject knight2Ban;
    public GameObject sword2Ban;
    public GameObject leva2Ban;
    public GameObject lance2Ban;


    private int ArmyP1, ArmyP2;

    //EVENT
    public static event Action<int> ArmySelectedP1;
    public static event Action<int> ArmySelectedP2;

    private void Start()
    {
        //animator = GetComponent<Animator>();

        //Se prenden selecciones for default
        SpriteLevaP1.SetActive(true);
        ArmyP1 = 1;

        knight1.SetActive(true);
        sword1.SetActive(true);
        leva1.SetActive(true);
        arch1.SetActive(false);
        lance1.SetActive(false);

        knight1Ban.SetActive(false);
        sword1Ban.SetActive(false);
        leva1Ban.SetActive(false);
        arch1Ban.SetActive(false);
        lance1Ban.SetActive(false);


        SpriteLevaP2.SetActive(true);
        ArmyP2 = 1;

        knight2.SetActive(true);
        sword2.SetActive(true);
        leva2.SetActive(true);
        arch2.SetActive(false);
        lance2.SetActive(false);

        knight2Ban.SetActive(false);
        sword2Ban.SetActive(false);
        leva2Ban.SetActive(false);
        arch2Ban.SetActive(false);
        lance2Ban.SetActive(false);
    }


    private void Update()
    {
        //Selector PLAYER 1
        //Faccion 1

        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1)){
            //Se Activa y limpian Selectores
            SpriteLevaP1.SetActive(true);
            SpriteTrinidadP1.SetActive(false);
            SpriteAntiP1.SetActive(false);
            SpriteLevaP1Ban.SetActive(false);
            SpriteTrinidadP1Ban.SetActive(false);
            SpriteAntiP1Ban.SetActive(false);
            ArmyP1 = 1;

            //Personajes en pantalla
            knight1.SetActive(true);
            sword1.SetActive(true);
            leva1.SetActive(true);
            arch1.SetActive(false);
            lance1.SetActive(false);

            knight1Ban.SetActive(false);
            sword1Ban.SetActive(false);
            leva1Ban.SetActive(false);
            arch1Ban.SetActive(false);
            lance1Ban.SetActive(false);
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpriteLevaP1.SetActive(false);
            SpriteTrinidadP1.SetActive(true);
            SpriteAntiP1.SetActive(false);
            SpriteLevaP1Ban.SetActive(false);
            SpriteTrinidadP1Ban.SetActive(false);
            SpriteAntiP1Ban.SetActive(false);
            ArmyP1 = 2;

            knight1.SetActive(true);
            sword1.SetActive(true);
            lance1.SetActive(true);
            arch1.SetActive(false);
            leva1 .SetActive(false);

            knight1Ban.SetActive(false);
            sword1Ban.SetActive(false);
            leva1Ban.SetActive(false);
            arch1Ban.SetActive(false);
            lance1Ban.SetActive(false);



        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpriteLevaP1.SetActive(false);
            SpriteTrinidadP1.SetActive(false);
            SpriteAntiP1.SetActive(true);
            SpriteLevaP1Ban.SetActive(false);
            SpriteTrinidadP1Ban.SetActive(false);
            SpriteAntiP1Ban.SetActive(false);
            ArmyP1 = 3;

            sword1.SetActive(true);
            leva1.SetActive(true);
            arch1.SetActive(true);
            lance1.SetActive (true);
            knight1.SetActive(false);

            knight1Ban.SetActive(false);
            sword1Ban.SetActive(false);
            leva1Ban.SetActive(false);
            arch1Ban.SetActive(false);
            lance1Ban.SetActive(false);
        }

        //Faccion 2
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha4))
        {
            SpriteLevaP1.SetActive(false);
            SpriteTrinidadP1.SetActive(false);
            SpriteAntiP1.SetActive(false);
            SpriteLevaP1Ban.SetActive(true);
            SpriteTrinidadP1Ban.SetActive(false);
            SpriteAntiP1Ban.SetActive(false);
            ArmyP1 = 4;

            knight1.SetActive(false);
            sword1.SetActive(false);
            leva1.SetActive(false);
            arch1.SetActive(false);
            lance1.SetActive(false);

            knight1Ban.SetActive(true);
            sword1Ban.SetActive(true);
            leva1Ban.SetActive(true);
            arch1Ban.SetActive(false);
            lance1Ban.SetActive(false);
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha5))
        {
            SpriteLevaP1.SetActive(false);
            SpriteTrinidadP1.SetActive(false);
            SpriteAntiP1.SetActive(false);
            SpriteLevaP1Ban.SetActive(false);
            SpriteTrinidadP1Ban.SetActive(true);
            SpriteAntiP1Ban.SetActive(false);
            ArmyP1 = 5;

            knight1.SetActive(false);
            sword1.SetActive(false);
            lance1.SetActive(false);
            arch1.SetActive(false);
            leva1.SetActive(false);

            knight1Ban.SetActive(true);
            sword1Ban.SetActive(true);
            leva1Ban.SetActive(false);
            arch1Ban.SetActive(false);
            lance1Ban.SetActive(true);



        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha6))
        {
            SpriteLevaP1.SetActive(false);
            SpriteTrinidadP1.SetActive(false);
            SpriteAntiP1.SetActive(false);
            SpriteLevaP1Ban.SetActive(false);
            SpriteTrinidadP1Ban.SetActive(false);
            SpriteAntiP1Ban.SetActive(true);
            ArmyP1 = 6;

            sword1.SetActive(false);
            leva1.SetActive(false);
            arch1.SetActive(false);
            lance1.SetActive(false);
            knight1.SetActive(false);

            knight1Ban.SetActive(false);
            sword1Ban.SetActive(true);
            leva1Ban.SetActive(true);
            arch1Ban.SetActive(true);
            lance1Ban.SetActive(true);
        }





        //Selector PLAYER 2
        //Faccion 1 
        if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
        {
            SpriteLevaP2.SetActive(true);
            SpriteTrinidadP2.SetActive(false);
            SpriteAntiP2.SetActive(false);
            SpriteLevaP2Ban.SetActive(false);
            SpriteTrinidadP2Ban.SetActive(false);
            SpriteAntiP2Ban.SetActive(false);
            ArmyP2 = 1;

            knight2.SetActive(true);
            sword2.SetActive(true);
            leva2.SetActive(true);
            arch2.SetActive(false);
            lance2.SetActive(false);

            knight2Ban.SetActive(false);
            sword2Ban.SetActive(false);
            leva2Ban.SetActive(false);
            arch2Ban.SetActive(false);
            lance2Ban.SetActive(false);

        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.W))
        {
            SpriteLevaP2.SetActive(false);
            SpriteTrinidadP2.SetActive(true);
            SpriteAntiP2.SetActive(false);
            SpriteLevaP2Ban.SetActive(false);
            SpriteTrinidadP2Ban.SetActive(false);
            SpriteAntiP2Ban.SetActive(false);
            ArmyP2 = 2;

            knight2.SetActive(true);
            sword2.SetActive(true);
            lance2.SetActive(true);
            arch2.SetActive (false);
            leva2.SetActive(false);

            knight2Ban.SetActive(false);
            sword2Ban.SetActive(false);
            leva2Ban.SetActive(false);
            arch2Ban.SetActive(false);
            lance2Ban.SetActive(false);
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            SpriteLevaP2.SetActive(false);
            SpriteTrinidadP2.SetActive(false);
            SpriteAntiP2.SetActive(true);
            SpriteLevaP2Ban.SetActive(false);
            SpriteTrinidadP2Ban.SetActive(false);
            SpriteAntiP2Ban.SetActive(false);
            ArmyP2 = 3;

            sword2.SetActive(true);
            leva2.SetActive(true);
            arch2.SetActive(true);
            lance2.SetActive(true);
            knight2.SetActive(false);

            knight2Ban.SetActive(false);
            sword2Ban.SetActive(false);
            leva2Ban.SetActive(false);
            arch2Ban.SetActive(false);
            lance2Ban.SetActive(false);
        }

        //Faccion 2
        if (UnityEngine.Input.GetKeyDown(KeyCode.R))
        {
            SpriteLevaP2.SetActive(false);
            SpriteTrinidadP2.SetActive(false);
            SpriteAntiP2.SetActive(false);
            SpriteLevaP2Ban.SetActive(true);
            SpriteTrinidadP2Ban.SetActive(false);
            SpriteAntiP2Ban.SetActive(false);
            ArmyP2 = 4;

            knight2.SetActive(false);
            sword2.SetActive(false);
            leva2.SetActive(false);
            arch2.SetActive(false);
            lance2.SetActive(false);

            knight2Ban.SetActive(true);
            sword2Ban.SetActive(true);
            leva2Ban.SetActive(true);
            arch2Ban.SetActive(false);
            lance2Ban.SetActive(false);

        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.T))
        {
            SpriteLevaP2.SetActive(false);
            SpriteTrinidadP2.SetActive(false);
            SpriteAntiP2.SetActive(false);
            SpriteLevaP2Ban.SetActive(false);
            SpriteTrinidadP2Ban.SetActive(true);
            SpriteAntiP2Ban.SetActive(false);
            ArmyP2 = 5;

            knight2.SetActive(false);
            sword2.SetActive(false);
            lance2.SetActive(false);
            arch2.SetActive(false);
            leva2.SetActive(false);

            knight2Ban.SetActive(true);
            sword2Ban.SetActive(true);
            leva2Ban.SetActive(false);
            arch2Ban.SetActive(false);
            lance2Ban.SetActive(true);
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Y))
        {
            SpriteLevaP2.SetActive(false);
            SpriteTrinidadP2.SetActive(false);
            SpriteAntiP2.SetActive(false);
            SpriteLevaP2Ban.SetActive(false);
            SpriteTrinidadP2Ban.SetActive(false);
            SpriteAntiP2Ban.SetActive(true);
            ArmyP2 = 6;

            sword2.SetActive(false);
            leva2.SetActive(false);
            arch2.SetActive(false);
            lance2.SetActive(false);
            knight2.SetActive(false);

            knight2Ban.SetActive(false);
            sword2Ban.SetActive(true);
            leva2Ban.SetActive(true);
            arch2Ban.SetActive(true);
            lance2Ban.SetActive(true);
        }

        //Iniciar Partida
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
           
            ArmySelectedP1?.Invoke(ArmyP1);
            ArmySelectedP2?.Invoke(ArmyP2);

           // animator.SetTrigger("EndScene");
            //StartCoroutine(SceneChange());

            SceneManager.LoadScene(3);
        }
    }


    //IEnumerator SceneChange()
    //{

    //    yield return new WaitForSeconds(3f);

    //      SceneManager.LoadScene(1);
    //}




}
