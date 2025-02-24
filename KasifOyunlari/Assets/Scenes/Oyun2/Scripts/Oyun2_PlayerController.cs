using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oyun2_PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float laneDistance = 3f; 
    private int currentLane = 0;
    public int score = 0;

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        Move();
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
        transform.position = Vector3.Lerp(transform.position, newPosition, 5f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (false)
        {
            //turk malı
            if (false)
            {
                score += 30;
                Debug.Log("Skor: " + score);
            }
            //boykot
            else if (false)
            {
                Debug.Log("Oyun Bitti! Skor: " + score);
                //Oyunu bitir
            }
        }
    }
}