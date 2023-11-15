using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Arch : Unit
{
    
    //raycast circular 2 casilleros
   
    //[SerializeField] public int units = 3;
    [SerializeField] private int actionPoints = 2;
    [SerializeField] public float attackRange = 1.65f;
    //[SerializeField] public int coste = 30;

    private int actionPointValue;

    public TMP_Text unitText;
    public TMP_Text canva;

    private void Start()
    {
        actionPointValue = actionPoints;

     
    }
    private void Update()
    {
        if(units <= 0)
        {
            gameObject.SetActive(false);
        }
        unitText.text = units.ToString();
    }

    public int GetUnitsNumber()
    {
        return units;
    }
    public void AddActionPoints(int value)
    {
        actionPoints += value;
    }
    public void SubUnitsNumber(int unitsNumber)
    {
        units = units - unitsNumber;
    }

    public int GetActionPoints()
    {
        return actionPoints;
    }

    public float GetAttackRange()
    {
        return attackRange;
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
