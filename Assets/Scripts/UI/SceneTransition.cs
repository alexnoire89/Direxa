using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip sceneFinal;




    private void Start()
    {
        animator = GetComponent<Animator>();
      //  StartCoroutine(SceneChange());
    }

   private void Update()
    {
       
    }

    IEnumerator SceneChange()
    {
        
        yield return new WaitForSeconds(3f);

      //  SceneManager.LoadScene(1);
    }
}
