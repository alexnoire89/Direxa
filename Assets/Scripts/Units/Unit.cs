using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //Se crea una clase para que maneje el costo y la logia de restar unidades para los poderes


    [SerializeField] protected int cost = 1;
    [SerializeField] protected int units = 3;


    public int GetCost()
    {
        return cost;
    }

    public void SubtractOneUnit()
    {
        units--;
        if (units <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
