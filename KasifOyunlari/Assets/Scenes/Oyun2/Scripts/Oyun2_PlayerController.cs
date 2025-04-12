using System;
using Scenes.Oyun2.Scripts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oyun2_PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    
    [Header("Movement")]
    public float moveSpeed = 7f;
    public float laneDistance = 2f; 
    private int currentLane = 1;
    private Vector3 targetPosition;
    private bool canMove = true;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        targetPosition = new Vector3(2f, transform.position.y, transform.position.z);
        
        MoveToLane();
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            MoveForward();
            MoveToLane();
        }
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0) && currentLane > 0) // Input.GetKeyDown(KeyCode.LeftArrow)
        {
            currentLane--;
            targetPosition = new Vector3(-laneDistance, transform.position.y, transform.position.z);
        }
        else if (Input.GetMouseButtonDown(0) && currentLane < 1) // Input.GetKeyDown(KeyCode.RightArrow)
        {
            currentLane++;
            targetPosition = new Vector3(laneDistance, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isFall", true);
        }
    }

    private void MoveForward()
    {
        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, moveSpeed);
    }

    private void MoveToLane()
    {
        Vector3 newPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        rb.MovePosition(Vector3.Lerp(transform.position, newPosition, Time.fixedDeltaTime * 5f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TR"))
        {
            Oyun2_GeneralEvents.OnScoreChanged(1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Boykot"))
        {
            rb.linearVelocity = Vector3.zero;
            canMove = false;
            animator.SetBool("isFall", true);
            Invoke("LoseGame", 1f);
        }
    }

    private void LoseGame()
    {
        Oyun2_GeneralEvents.OnGameOver.Invoke();
    }
}
