using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Kod_KopruGecmece_Arayuz : MonoBehaviour
{
    public List<string> lst_kelimeler = new List<string>();

    public string arananKelime; 
    public char[] arr_arananKelime;

    public TMP_Text tx_ekrandakiKelime;
    public char[] arr_ekrandakiKelime; 
    
    //public TMP_InputField inputKelime;

    public int bulunanHarfSayisi = 0;

    public Image tavsan;

    public Transform kazandiniz;
    public bool kazandinizMi = false;

    public int can = 0;
    public TMP_Text tx_can;

    void Start()
    {
        // Büyük harfli kelimeler ekliyoruz
        // TODO kelime ve kategori seklinde ekleyecegiz.
        lst_kelimeler.Add("TÜRKİYE");
        lst_kelimeler.Add("AFYON");
        lst_kelimeler.Add("ANKARA");
        lst_kelimeler.Add("İZMİR");
        lst_kelimeler.Add("BURSA");
        lst_kelimeler.Add("VAN");
        lst_kelimeler.Add("BAYBURT");
        lst_kelimeler.Add("BİNGÖL");
        lst_kelimeler.Add("ADANA");
        lst_kelimeler.Add("AYDIN");
        lst_kelimeler.Add("KARAMAN");
        lst_kelimeler.Add("MALATYA");
        lst_kelimeler.Add("BURDUR");
        lst_kelimeler.Add("DENİZLİ");
        lst_kelimeler.Add("ISPARTA");
        lst_kelimeler.Add("MARDİN");
        lst_kelimeler.Add("SAKARYA");
        lst_kelimeler.Add("KAYSERİ");
        lst_kelimeler.Add("ERZURUM");
        lst_kelimeler.Add("NİĞDE");
        lst_kelimeler.Add("KIRŞEHİR");
        lst_kelimeler.Add("ERBAKAN");
        lst_kelimeler.Add("SAADET");
        lst_kelimeler.Add("ANADOLU");
        lst_kelimeler.Add("GENÇLİK");
        lst_kelimeler.Add("FİLİSTİN");
        lst_kelimeler.Add("NİJERJA");
        lst_kelimeler.Add("ENDONEZYA");
        lst_kelimeler.Add("MISIR");
        lst_kelimeler.Add("CİHAD");
        lst_kelimeler.Add("PAKİSTAN");
        lst_kelimeler.Add("İRAN");
        lst_kelimeler.Add("MALEZYA");
        lst_kelimeler.Add("BANGLADEŞ");

        ArananKelimeyiBelirle();
    }

    void ArananKelimeyiBelirle()
    {
        // listeden rasgele belirlenecek !
        arananKelime = lst_kelimeler[UnityEngine.Random.Range(0, lst_kelimeler.Count)];

        // char array dönüştür
        arr_arananKelime = arananKelime.ToCharArray();
        
        // can sayisini belirle
        can = arr_arananKelime.Length + 3;
        tx_can.text = can.ToString();

        // ekrandaki kelimeyi olustur
        tx_ekrandakiKelime.text = "";

        for (int i = 0; i < arananKelime.Length; i++)
        {
            tx_ekrandakiKelime.text += "_";           
        }

        // ekrandaki kelimeyi de char array dönüştür
        arr_ekrandakiKelime = tx_ekrandakiKelime.text.ToCharArray();
    }

    public void Buton_HarfVarMi(char harf)
    {
        if (!kazandinizMi && can > 0)
        {          
        
            //inputKelime.text = inputKelime.text.ToUpper();

            char girilenHarf = harf;

            bool bulunanHarfOlduMu = false;

            for (int i = 0; i < arr_arananKelime.Length; i++)
            {
                if (arr_arananKelime[i] == girilenHarf)
                {
                    arr_ekrandakiKelime[i] = girilenHarf;

                    bulunanHarfSayisi++;

                    bulunanHarfOlduMu = true;
                }    
            }

            if (bulunanHarfOlduMu)
            {
                // ekrandaki kelimeyi yenile
                EkrandakiKelimeyiYenile();

                // Tüm kelime bilinmiş mi kontrol et
                TumKelimeBitmisMiKontrolEt();

                // Tavsani ilerlet
                TavsaniIlerlet();
            }
            else
            {
                can--;

                tx_can.text = can.ToString();

                if (can <= 0)
                {
                    // kaybettiniz
                    kazandiniz.GetComponent<TMP_Text>().text = "Kaybettiniz !";

                    kazandiniz.gameObject.SetActive(true);
                }
            }

        }     
    }

    void EkrandakiKelimeyiYenile()
    {
        string geciciKelime = "";

        for (int i = 0; i < arr_ekrandakiKelime.Length; i++)
        {
            geciciKelime += arr_ekrandakiKelime[i];    
        }

        tx_ekrandakiKelime.text = geciciKelime;
    }
    
    void TumKelimeBitmisMiKontrolEt()
    {
        if (arananKelime == tx_ekrandakiKelime.text)
        {
            Debug.Log("Oyun bitti");

            kazandinizMi = true;

            kazandiniz.gameObject.SetActive(true);
        }
    }

    void TavsaniIlerlet()
    {
        // gidilecek pozisyonu belirle // toplam mesafe 700 birim
        Vector3 gidilecekPozisyon = 
                        new Vector3(-300 + (Mathf.Round(bulunanHarfSayisi) / arr_arananKelime.Length) * 600,
                                     100,
                                     0
                                   );
        
        //Debug.Log("GİDİLECEK POZİSYON: " + gidilecekPozisyon);

        //tavsan.rectTransform.localPosition = new Vector3(-50,100,0);
        tavsan.rectTransform.localPosition = gidilecekPozisyon;
    }

    // Genel butonlar
    public void Buton_AnaSahneyeGit()
    {
        SceneManager.LoadScene(0);
    }
    public void Buton_YenidenOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
