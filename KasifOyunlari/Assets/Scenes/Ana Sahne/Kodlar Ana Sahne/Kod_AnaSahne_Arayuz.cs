using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kod_AnaSahne_Arayuz : MonoBehaviour
{
    #region Degiskenler

    public Transform tr_Panel_AnaMenu;
    public Transform tr_Panel_KacKisiSecimi;
    public Transform tr_Panel_Yukleniyor;


    private int secilen_OyunNumarasi;
    private int secilen_KacKisilikNumarasi;

    #endregion

    void Start()
    {
        
    }

    
    public void Buton_Oyun(int oyunNumarasi)
    {
        secilen_OyunNumarasi = oyunNumarasi;

        // Panel Degistir
        tr_Panel_AnaMenu.gameObject.SetActive(false);
        tr_Panel_KacKisiSecimi.gameObject.SetActive(true);
    }

    public void Buton_KacKisi(int kisiSayisi)
    {
        //Kac Kisilik oyun olacagini hafizaya kaydet
        secilen_KacKisilikNumarasi = kisiSayisi;
        PlayerPrefs.SetInt("KacKisilik", secilen_KacKisilikNumarasi);

        // Panel Degistir
        tr_Panel_KacKisiSecimi.gameObject.SetActive(false);
        tr_Panel_Yukleniyor.gameObject.SetActive(true);

        // Beklet ve sahne degistir
        StartCoroutine(OyunSahnesineGit());
    }

    IEnumerator OyunSahnesineGit()
    {
        // Beklet
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(secilen_OyunNumarasi);
    }


}
