using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice : MonoBehaviour
{
    public ShowText dices;


    public bool comp1;
    public bool comp2;
    public bool comp3;

    public int dado1P1, dado2P1, dado3P1, dado4P2, dado5P2, dado6P2;
    public void LanzarDado()
    {
        // Generar números aleatorios entre 1 y 12 para los tres dados
        int dado1 = Random.Range(1, 13);
        int dado2 = Random.Range(1, 13);
        int dado3 = Random.Range(1, 13);

        // Mostrar dos reultados del lanzamiento de los dados de LanzarDado
        //Debug.Log("dado 1 " + dado1);
        //Debug.Log("dado 2 " + dado2);
        //Debug.Log("dado 3 " + dado3);

        dices.ShowDices();

        // Lanzar los dados de LanzarDado2 y comparar los resultados
        LanzarDado2(dado1, dado2, dado3);
    }

    public void LanzarDado2(int dado1, int dado2, int dado3)
    {
        // Generar números aleatorios entre 1 y 12 para los tres dados
        int dado4 = Random.Range(1, 13);
        int dado5 = Random.Range(1, 13);
        int dado6 = Random.Range(1, 13);

        // Mostrar los resultados del lanzamiento de los dados de LanzarDado2
        //Debug.Log("dado 4 " + dado4);
        //Debug.Log("dado 5 " + dado5);
        //Debug.Log("dado 6 " + dado6);

        // Comparar los resultados con los dados de LanzarDado
        //CompararResultados(dado1, dado2, dado3, dado4, dado5, dado6);


        dado1P1 = dado1;
        dado2P1 = dado2;
        dado3P1 = dado3;
        dado4P2 = dado4;
        dado5P2 = dado5;
        dado6P2 = dado6;
        
    }




    public void CompararResultados(int dado1, int dado2, int dado3, int dado4, int dado5, int dado6)
    {
        if (dado1 > dado4)
        {

            comp1 = true;
            //Debug.Log("Dado 1 es mayor que Dado 4 ");
            dices.Dado1P1.color = Color.green;
            dices.Dado4P2.color = Color.red;
        }
        else if (dado1 < dado4)
        {
            comp1 = false;
            //Debug.Log("Dado 4 es mayor que Dado 1 ");
            dices.Dado1P1.color = Color.red;
            dices.Dado4P2.color = Color.green;
        }
        else
        {
            //Debug.Log("Dado 1  es igual a Dado 4 ");
            dices.Dado1P1.color = Color.black;
            dices.Dado4P2.color = Color.black;
        }
        //Segunda comparacion
        if (dado2 > dado5)
        {
            comp2 = true;
            //Debug.Log("Dado 2 es mayor que Dado 5 ");
            dices.Dado2P1.color = Color.green;
            dices.Dado5P2.color = Color.red;
        }
        else if (dado2 < dado5)
        {
            comp2 = false;
            //Debug.Log("Dado 5 es mayor a dado 2");
            dices.Dado2P1.color = Color.red;
            dices.Dado5P2.color = Color.green;
        }
        else
        {
            //Debug.Log("Dado 2 es igual a Dado5");
            dices.Dado2P1.color = Color.black;
            dices.Dado5P2.color = Color.black;
        }
        //Tercera comparacion
        if (dado3 > dado6)
        {
            comp3 = true;
            //Debug.Log("Dado 3 es mayor que Dado 6");
            dices.Dado3P1.color = Color.green;
            dices.Dado6P2.color = Color.red;
        }
        else if (dado3 < dado6)
        {
            comp3 = false;
            //Debug.Log("Dado 6 es mayor que dado 3");
            dices.Dado3P1.color = Color.red;
            dices.Dado6P2.color = Color.green;
        }
        else
        {
            //Debug.Log("Dado 3 es igual que dado6");
            dices.Dado3P1.color = Color.black;
            dices.Dado6P2.color = Color.black;
        }
    }



}
