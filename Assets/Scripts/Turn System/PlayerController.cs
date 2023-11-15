using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Layers que bloquean camino")]
    public LayerMask layerMask;

    private Vector2 targetPosition;
    private Vector2 nextPosition;

    private float xInput, yInput;

    //Personajes escala 1.2
    //Valores por defecto segun tamaños de sprite y Hexas
    [SerializeField] public float moveTime = 0.15f;
    [SerializeField] public float moveDistanceX = 0.93f;
    [SerializeField] public float moveDistanceXY = 0.46f;
    [SerializeField] public float moveDistanceYX = 0.54f;


    private bool isMoving, isLookingRight = true;

    [Header("ActionPoints")]
    [SerializeField] public int actionPoints;

    private int turnActionPoints;

    private int playerLayer;

    public Sword sword;
    public Arch arch;
    public Lance lance;
    public Knight knight;
    public Leva leva;
    public zone zone;


    private void Start()
    {
       
        targetPosition = transform.position;

    
         InitiateActionsPoints();

    }

    void Update()
    {
      

        //Getaxisraw devuelve -1 al apretar izquierda, 1 a la derecha. arriba 1, abajo -1. Si no se apreta nada 0
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

            //Si es distinto de cero, se pulso alguna flecha
            if ((xInput != 0f ) && !isMoving && Input.anyKeyDown && actionPoints > 0)
            {

                CalculateTargetPosition();

                 if (CanMoveNextPosition())
                 {

                     StartCoroutine(Move());
                     actionPoints--;

                  }
                

            }

       
     }



    private void FlipSprite()
    {
        if(xInput == -1f && isLookingRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            isLookingRight = false;
        }

        if (xInput == 1f && !isLookingRight)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            isLookingRight = true;
        }
    }

    public void InitiateActionsPoints()
    {
        //Preguntar que clase es para accionar puntos de movimiento
        if (gameObject.TryGetComponent<Sword>(out sword))
        {
            actionPoints = sword.GetComponent<Sword>().GetActionPoints();
            playerLayer = sword.gameObject.layer;

        }

        if (gameObject.TryGetComponent<Arch>(out arch))
        {
            actionPoints = arch.GetComponent<Arch>().GetActionPoints();
            playerLayer = arch.gameObject.layer;
        }

        if (gameObject.TryGetComponent<Lance>(out lance))
        {
            actionPoints = lance.GetComponent<Lance>().GetActionPoints();
            playerLayer = lance.gameObject.layer;
        }

        if (gameObject.TryGetComponent<Knight>(out knight))
        {
            actionPoints = knight.GetComponent<Knight>().GetActionPoints();
            playerLayer = knight.gameObject.layer;
        }

        if (gameObject.TryGetComponent<Leva>(out leva))
        {
            actionPoints = leva.GetComponent<Leva>().GetActionPoints();
            playerLayer = leva.gameObject.layer;
        }
    }



    public void InitiateActionsPointsPlus()
    {
        //Preguntar que clase es para accionar puntos de movimiento
        if (gameObject.TryGetComponent<Sword>(out sword))
        {
            actionPoints = sword.GetComponent<Sword>().GetActionPoints() + 2;
            playerLayer = sword.gameObject.layer;

        }

        if (gameObject.TryGetComponent<Arch>(out arch))
        {
            actionPoints = arch.GetComponent<Arch>().GetActionPoints() + 2;
            playerLayer = arch.gameObject.layer;
        }

        if (gameObject.TryGetComponent<Lance>(out lance))
        {
            actionPoints = lance.GetComponent<Lance>().GetActionPoints() + 2;
            playerLayer = lance.gameObject.layer;
        }

        if (gameObject.TryGetComponent<Knight>(out knight))
        {
            actionPoints = knight.GetComponent<Knight>().GetActionPoints() + 2;
            playerLayer = knight.gameObject.layer;
        }

        if (gameObject.TryGetComponent<Leva>(out leva))
        {
            actionPoints = leva.GetComponent<Leva>().GetActionPoints() + 2;
            playerLayer = leva.gameObject.layer;
        }
    }


    //corrutina para movimiento con interpolacion lineal
    IEnumerator Move()
    {
        isMoving = true;

        float timeElapsed = 0f;
        Vector2 startPosition = transform.position;

        FlipSprite();

        while (timeElapsed < moveTime)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, timeElapsed / moveTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        
        transform.position = targetPosition;


        isMoving = false;
    }



    private bool CanMoveNextPosition()
    {
        //Si no hay ningun collider en el proximo movimiento devuelve verdadero porque negamos con !
        //return !Physics2D.OverlapCircle(targetPosition, 0.15f, playerLayer);
        return !Physics2D.OverlapCircle(targetPosition, 0.15f, layerMask);
    }


    private void CalculateTargetPosition()
    {
          if(xInput == 1f)
          {
              targetPosition = (Vector2)transform.position + Vector2.right * moveDistanceX;
            
        }

          if (xInput == -1f)
          {
              targetPosition = (Vector2)transform.position + Vector2.left * moveDistanceX;
            
        }


        //Diagonales

        if (xInput == 1f && yInput == 1f)
        {

            targetPosition = (Vector2)transform.position + Vector2.right * moveDistanceXY + Vector2.up * moveDistanceYX;
        }

        if (xInput == 1f && yInput == -1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.right * moveDistanceXY + Vector2.down * moveDistanceYX;
        }

        if (xInput == -1f && yInput == 1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.left * moveDistanceXY + Vector2.up * moveDistanceYX;
        }

        if (xInput == -1f && yInput == -1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.left * moveDistanceXY + Vector2.down * moveDistanceYX;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetPosition, 0.15f);
    }


}
