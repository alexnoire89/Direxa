using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UnitText : MonoBehaviour
{


    private TextMeshProUGUI textMesh;

    public Sword sword;
    public Arch arch;
    public Lance lance;
    public Knight knight;




    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();


    }



    void Update()
    {
        //Preguntar que clase es para tomar los puntos de unidades
        if (gameObject.TryGetComponent<Sword>(out sword))
        {
            textMesh.text = sword.GetComponent<Sword>().GetUnitsNumber().ToString();
        }

        if (gameObject.TryGetComponent<Arch>(out arch))
        {
            textMesh.text = arch.GetComponent<Arch>().GetUnitsNumber().ToString();
        }

        if (gameObject.TryGetComponent<Lance>(out lance))
        {
            textMesh.text = lance.GetComponent<Lance>().GetUnitsNumber().ToString();
        }

        if (gameObject.TryGetComponent<Knight>(out knight))
        {
            textMesh.text = knight.GetComponent<Knight>().GetUnitsNumber().ToString();
        }
    }


}