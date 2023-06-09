using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour, IMoveable, IControlable
{
    [Header("Stats")]
    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float distanceMoveAgain = 0.1f;
    [SerializeField] private int detik;
    [Header("References")]
    [SerializeField] private IMoveable moveable;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private LayerMask wallLayer;
    private Vector3 moveTarget;
    private Vector3 moveDirectionBuffer = Vector3.zero;
    private float distanceToTarget;

    [ContextMenu("Ini Method Baru")]
    /// <summary>
    /// Ini method baru 
    /// </summary>
    /// <param name="number">Ini parameter number</param>
    /// <param name="angka">Ini parameter angka</param>
    /// <returns>return apa ini</returns>    
    public void MethodBaru()
    {
        Debug.Log($"{detik/3600}:{(detik%3600)/60}:{detik%60}");
    }
    
    private void Start()
    {
        moveTarget = transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {

        if (!gameManager.CanMove) return;

        distanceToTarget = Vector3.Distance(transform.position, moveTarget);

        if(distanceToTarget < distanceMoveAgain)
        { 
            HandleInput();
        }
        if (moveDirectionBuffer != Vector3.zero && distanceToTarget <= 0)
        {
            ShiftMoveTarget(moveDirectionBuffer);
            moveDirectionBuffer = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        detik++;
        if (detik > 300)
        {
            Debug.Log("Sudah 5 detik");
        }

        if (distanceToTarget > 0)
        {
            MovePosition();
        }
    }

    public void HandleInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveDirectionBuffer = Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirectionBuffer = Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirectionBuffer = Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirectionBuffer = Vector2.right;
        }        
    }

    public bool CheckCollision(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(moveTarget, direction, 1f, wallLayer);
        if (hit.collider != null) 
            return true;
        return false;
    }

    public void MovePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTarget, moveSpeed);
    }

    public void ShiftMoveTarget(Vector3 direction)
    {
        if(!CheckCollision(direction))
            moveTarget += direction;
    }
}
