using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonec : MonoBehaviour
{
    // Start is called before the first frame update
    public bool captureCp1 = false;
    public bool captureCp2 = false;

    public int points1;
    public int points2;

    public GameObject capturaC1;
    public GameObject capturaC2;

    private void Start()
    {
        capturaC1.SetActive(false);
        capturaC2.SetActive(false);
    }
    private void Update()
    {
        if (captureCp1 == true)
        {
            capturaC1.SetActive (true);
            capturaC2.SetActive (false);
            captureCp2 = false;
        }

        if (captureCp2 == true)
        {
            capturaC2.SetActive (true);
            capturaC1.SetActive(false);
            captureCp1 = false;
        }

    }



 
}
