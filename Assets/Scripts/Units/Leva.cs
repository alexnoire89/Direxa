using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Leva : Unit
{
    [SerializeField] private int actionPoints = 2;
   
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


    public void AddActionPoints(int value)
    {
        actionPoints +=value;
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

    public void RestartActionPoints(int actionPointsValue)
    {
        actionPoints = actionPointsValue;


    }

    public void RestartActionPoints()
    {
        actionPoints = actionPointValue;
    }
}
