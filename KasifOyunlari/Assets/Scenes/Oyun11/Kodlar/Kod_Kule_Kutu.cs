using System;
using UnityEngine;

public class Kod_Kule_Kutu : MonoBehaviour
{
    Rigidbody rb;

    public Transform tr_Arayuz;

    Kod_Kule_Arayuz kod_Arayuz;
    
    //public int hiz;

    bool pasifMi;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        tr_Arayuz = GameObject.FindGameObjectWithTag("Arayuz").transform;
        
        kod_Arayuz = tr_Arayuz.GetComponent<Kod_Kule_Arayuz>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (!pasifMi)
        {
            if (other.transform.CompareTag("zemin"))
            {
                OyunBitti();
            }
            else if (other.transform.CompareTag("sonKutu"))
            {
                other.transform.tag = "zemin";
            
                KutuyaSabitle();
            }
        }
    }
    
    public void KutuyaSabitle()
    {
        pasifMi = true;
        
        rb.useGravity = false;
        rb.isKinematic = true;

        transform.tag = "sonKutu";
        
        kod_Arayuz.PuanKazandi();
    }

    public void KutuyuDusur()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }
    
    public void OyunBitti()
    {
        kod_Arayuz.OyunBitti();
    }

}
