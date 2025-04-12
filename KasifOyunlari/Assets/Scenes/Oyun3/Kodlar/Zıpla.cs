using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Zıpla : MonoBehaviour
{
    public float jumpcount;
    Rigidbody2D rb;
    public Text skorT;
    public float skor;
    
    public Text sonucT;
    
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
            sonucT.text = "Kaybettiniz...";
            
            Time.timeScale = 0;
        }
    }
    
    public void Buton_AnaSahneyeGit()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene(0);
    }
    public void Buton_YenidenOyna()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
