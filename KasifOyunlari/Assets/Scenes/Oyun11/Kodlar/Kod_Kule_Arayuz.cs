using System;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class Kod_Kule_Arayuz : MonoBehaviour
{
    public TMP_Text tx_Sonuc;
    public TMP_Text tx_Puan;
    int puan;
    
    public GameObject go_Kutu;
    
    public Transform tr_Kanca;
    public Transform tr_KancaKutuNoktasi;

    public int kanca_hiz;
    public int kanca_yonu;
    public int kanca_menzil;
    
    public bool oyunDursunMu;

    GameObject go_OlusturulanKutu;
    
    void Start()
    {
        YeniKutuSallat();
    }
    void Update()
    {
        if (!oyunDursunMu)
        {
            tr_Kanca.transform.Translate(Vector3.right * kanca_hiz * kanca_yonu * Time.deltaTime);

            if (Math.Abs(tr_Kanca.transform.position.x) > kanca_menzil)
            {
                kanca_yonu *= -1;
            }
        }

        if (Input.GetMouseButtonDown(0)) // Input.GetKeyDown(KeyCode.Space)
        {
            KutuyuSerbestBirak();
        }
    }

    public void PuanKazandi()
    {
        tx_Puan.text = (++puan).ToString();
        
        // kamerayi ve kancayi yukselt (kutu boyu 3 birim)
        Camera.main.transform.position += (Vector3.up * 1.5f);
        
        kanca_hiz++;    
        
        YeniKutuSallat();
    }
    
    public void YeniKutuSallat()
    {
        go_OlusturulanKutu = Instantiate(go_Kutu, tr_KancaKutuNoktasi.position, quaternion.identity);

        go_OlusturulanKutu.transform.parent = tr_KancaKutuNoktasi;
        
        oyunDursunMu = false;
    }
    
    public void KutuyuSerbestBirak()
    {
        oyunDursunMu = true;

        go_OlusturulanKutu.transform.parent = null;
        go_OlusturulanKutu.GetComponent<Kod_Kule_Kutu>().KutuyuDusur();
    }
    
    public void OyunBitti()
    {
        tx_Sonuc.color = Color.red;
        tx_Sonuc.text = "Kaybettiniz.";
    }
    
    public void Buton_AnaSahneyeGit()
    {
        SceneManager.LoadScene(0);
    }
    public void Buton_YenidenOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
