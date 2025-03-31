using UnityEngine;
using UnityEngine.UI;

public class Zıpla : MonoBehaviour
{
    public float jumpcount;
    Rigidbody2D rb;
    public Text skorT;
    public float skor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        skor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            rb.linearVelocity = Vector2.up * jumpcount;
        }
        skorT.text = skor.ToString();
    }
    private void OnTriggerEnter2D(Collider2D temas)
    {
        if(temas.gameObject.tag=="Scorer")
        {
            skor++;
        }
    }
    private void OnCollisionEnter2D(Collision2D temas)
    {
        if(temas.gameObject.tag =="Engel")
        {
            Time.timeScale = 0;
        }
    }
}
