using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ShowText : MonoBehaviour
{

    public GameObject Dicecontrol1;
    public TMP_Text Dado1P1;
    public TMP_Text Dado2P1;
    public TMP_Text Dado3P1;

    public GameObject Dicecontrol2;
    public TMP_Text Dado4P2;
    public TMP_Text Dado5P2;
    public TMP_Text Dado6P2;

    public dice dice;

    public void ShowDices()
    {

        Dicecontrol1.SetActive(true);
        Dicecontrol2.SetActive(true);
        Dado1P1.text = dice.dado1P1 + "\n";
        Dado2P1.text = dice.dado2P1 + "\n";
        Dado3P1.text = dice.dado3P1 + "\n";

        Dado4P2.text = dice.dado4P2 + "\n";
        Dado5P2.text = dice.dado5P2 + "\n";
        Dado6P2.text = dice.dado6P2 + "\n";
    }

    public void HideDices()
    {
        Dicecontrol1.SetActive(false);
        Dicecontrol2.SetActive(false);
    }
    void Update()
    {
        Dado1P1.text = dice.dado1P1 + "\n";
        Dado2P1.text = dice.dado2P1 + "\n";
        Dado3P1.text = dice.dado3P1 + "\n";

        Dado4P2.text = dice.dado4P2 + "\n";
        Dado5P2.text = dice.dado5P2 + "\n";
        Dado6P2.text = dice.dado6P2 + "\n";
    }




}