using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class zone : MonoBehaviour
{
    public bool capturep1 = false;
    public bool capturep2 = false;

    public int points1;
    public int points2;

    public TMP_Text texp1;
    public TMP_Text texp2;

    public GameObject captura1;
    public GameObject captura2;


    private void Start()
    {
        captura1.SetActive(false);
        captura2.SetActive(false);
    }

    private void Update()
    {
        texp1.text = points1.ToString();
        texp2.text = points2.ToString();
 

        if (capturep1 == true)
        {
            captura1.SetActive(true);
            captura2.SetActive(false);
            capturep2 = false;
        }

        if (capturep2 == true)
        {
            captura2.SetActive(true);
            captura1.SetActive(false);
            capturep1 = false;
        }





    }
}
