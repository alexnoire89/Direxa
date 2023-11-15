using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneb : MonoBehaviour
{
    // Start is called before the first frame update
    public bool captureBp1 = false;
    public bool captureBp2 = false;



    public GameObject capturaB1;
    public GameObject capturaB2;

    private void Start()
    {
        capturaB1.SetActive(false);
        capturaB2.SetActive(false);

    }
    private void Update()
    {
        if (captureBp1 == true)
        {
            capturaB1.SetActive(true);
            capturaB2.SetActive(false);
            captureBp2 = false;
        }

        if (captureBp2 == true)
        {
            capturaB1.SetActive(false);
            capturaB2.SetActive(true);
            captureBp1 = false;
        }
    }
        

}
