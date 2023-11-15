using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexaDistance : MonoBehaviour
{
    public LayerMask capaObjetos; 



    void Update()
    {
        //Physics.Simulate(Time.fixedDeltaTime);

        // Configura el punto y el radio del c�rculo de colisi�n.
        Vector2 punto = transform.position;
        float radio = 0.5f;

        // Realiza una comprobaci�n de colisi�n continua en un �rea circular.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(punto, radio, capaObjetos);

        if (colliders.Length > 0)
        {

            gameObject.SetActive(false);

        }
        else gameObject.SetActive(true);


    }


    //    Debug.Log("sumador: " + alphaValueSum);
    //    Debug.Log("alphavalue: " + alphaValue);

    //    if (!useFixedUpdate)
    //    {
    //        if(alphaValueSum >= 0)
    //        {
    //            gameObject.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, alphaValue * Time.deltaTime);
    //            alphaValueSum++;
    //        }

    //        else if (alphaValueSum <= 10)
    //        {
    //            gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, alphaValue * Time.deltaTime);
    //            alphaValueSum--;

    //        }

    //    }

    //}

    //private void FixedUpdate()
    //{
    //    if (useFixedUpdate)
    //    {
    //        if (alphaValueSum >= 0)
    //        {
    //            gameObject.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, alphaValue * Time.deltaTime);
    //            alphaValueSum++;
    //        }

    //        else if (alphaValueSum <= 10)
    //        {
    //            gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, alphaValue * Time.deltaTime);
    //            alphaValueSum--;
    //        }
    //    }
    //}

}
