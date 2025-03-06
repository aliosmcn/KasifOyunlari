using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oyun2_PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    public float moveSpeed = 5f;
    public float laneDistance = 2f; 
    private int currentLane = 0;
    public int score = 0;
    
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject finishText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            finishText.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        Move();
    }

    private void FixedUpdate()
    {
        //rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, moveSpeed);
        float move = moveSpeed * Time.fixedDeltaTime;
        Vector3 newPosition = rb.position + transform.forward * move;
        rb.MovePosition(newPosition);
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 1)
        {
            currentLane++;
        }
        MoveToLane();
    }

    void MoveToLane()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = currentLane == 0 ? -laneDistance : laneDistance;
        newPosition.y = transform.position.y; // Y eksenini koru
        transform.position = Vector3.Lerp(transform.position, newPosition, 5f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boykot"))
        {
            score = 0;
            scoreText.text = "Skor: " + score;
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.CompareTag("TR"))
        {
            score++; 
            scoreText.text = "Skor: " + score;
            if (score == 9)
            {
                finishText.SetActive(true);
                Debug.Log("Kaşif kazandı!");
            }
        }
    }
}