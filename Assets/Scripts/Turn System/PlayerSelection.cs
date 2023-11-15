using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{

    public GameObject select;
    public GameObject selectKnight;
    public GameObject selectFlag;

    public GameObject selectPlus;
    public GameObject selectKnightPlus;


    [SerializeField] public float offsetX = 1.88f, offsetY = 0.37f;




    public void Select(bool selectBool)
    {
        this.select.SetActive(selectBool);


    }

    public void SelectPlus(bool selectBool)
    {
        this.selectPlus.SetActive(selectBool);


    }


    public void SelectFlag(bool selectBool)
    {
        this.selectFlag.SetActive(selectBool);


    }

    public void PaintHexas()
    {
        //select.SetActive(true);
        foreach (Transform hijo in select.transform)
        {
            //Activa el objeto hijo
            hijo.gameObject.SetActive(true);
        }

    }

    public void PaintHexasPlus()
    {
        //select.SetActive(true);
        foreach (Transform hijo in selectPlus.transform)
        {
            //Activa el objeto hijo
            hijo.gameObject.SetActive(true);
        }

    }

    public void PaintHexasKnight()
    {
        //selectKnight.SetActive(true);
        foreach (Transform hijo in selectKnight.transform)
        {
            //Activa el objeto hijo
            hijo.gameObject.SetActive(true);
        }
    }

    public void PaintHexasKnightPlus()
    {
        //selectKnight.SetActive(true);
        foreach (Transform hijo in selectKnightPlus.transform)
        {
            //Activa el objeto hijo
            hijo.gameObject.SetActive(true);
        }
    }




    public void SelectKnight(bool selectBool)
    {
        this.selectKnight.SetActive(selectBool);


    }

    public void SelectKnightPlus(bool selectBool)
    {
        this.selectKnightPlus.SetActive(selectBool);


    }

    public void SetPositionPlayer(Vector2 position)
    {
        select.transform.position = new Vector2(position.x - offsetX, position.y - offsetY);
    }

    public void SetPositionPlayerKnight(Vector2 position)
    {

        selectKnight.transform.position = new Vector2(position.x - offsetX, position.y - offsetY);
    }


    public void SetPositionPlayerPlus(Vector2 position)
    {
        selectPlus.transform.position = new Vector2(position.x - offsetX, position.y - offsetY);
    }

    public void SetPositionPlayerKnightPlus(Vector2 position)
    {

        selectKnightPlus.transform.position = new Vector2(position.x - offsetX, position.y - offsetY);
    }



}
