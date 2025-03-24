using UnityEngine;

public class Zıpla : MonoBehaviour
{
    public float jumpcount;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            rb.linearVelocity = Vector2.up * jumpcount;
        }
    }
}
