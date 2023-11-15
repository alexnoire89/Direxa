using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sword : Unit
{

    [SerializeField] private int actionPoints = 2;
   // [SerializeField] public int units = 3;
    //[SerializeField] public int coste = 20;

    public TMP_Text unitText;
    public TMP_Text canva;

    private int actionPointValue;

    private void Start()
    {
        actionPointValue = actionPoints;
    }
    private void Update()
    {
        if (units <= 0)
        {
            gameObject.SetActive(false);

        }

        unitText.text = units.ToString();
    }



    public int GetUnitsNumber()
    {
        return units;
    }
    public int GetActionPoints()
    {
        return actionPoints;
    }
    public void SubUnitsNumber(int unitsNumber)
    {
        units = units - unitsNumber;
    }


    public void SubActionPoints()
    {
        actionPoints--;
    }

    public void AddActionPoints(int value)
    {
        actionPoints += value;
    }

    public void  RestartActionPoints(int actionPointsValue)
    {
        actionPoints = actionPointsValue;


    }

    public void RestartActionPoints()
    {
        actionPoints = actionPointValue;
    }
}
