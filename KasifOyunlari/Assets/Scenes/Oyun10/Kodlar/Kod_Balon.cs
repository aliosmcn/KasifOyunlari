using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kod_Balon : MonoBehaviour
{    
    float hiz;

    public Transform tr_Arayuz;
    void Start()
    {
        RenkDegistir();

        HizDegistir();

        tr_Arayuz = GameObject.FindGameObjectWithTag("Arayuz").transform;
    }

    void Update()
    {
        transform.Translate(Vector3.back * hiz * Time.deltaTime);

        if (transform.position.y > 8)
        {
            // Can eksilt
            tr_Arayuz.GetComponent<Kod_Arayuz_BalonPatlatma>().CanMiktariGuncelle(-1);

            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown() 
    {
        // patlama sesi eklenecek
        // balonun patlatildigini haber ver
        tr_Arayuz.GetComponent<Kod_Arayuz_BalonPatlatma>().BalonPatlatildi();

        Destroy(this.gameObject);
    }

    void RenkDegistir()
    {
        this.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); //Random.ColorHSV(); 
    }

    void HizDegistir()
    {
         hiz = Random.Range(.5f, 2f);
    }
}
