using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Kod_Arayuz_BalonPatlatma : MonoBehaviour
{
    public int canMiktari;
    public int baslangic_canMiktari;
    public TMP_Text txt_canMiktari;

    public Transform balonPrefab;
    public int kacBalonUretilsin;

    int patlayanBalonSayisi = 0;
    void Start()
    {
        canMiktari = baslangic_canMiktari;

        txt_canMiktari.text = canMiktari.ToString();

        StartCoroutine(BeklediktenSonraUret());
    }

    IEnumerator BeklediktenSonraUret()
    {
        yield return new WaitForSeconds(1);

        BalonUret();
    }

    public void CanMiktariGuncelle(int gelenCan)
    {
        canMiktari += gelenCan;

        txt_canMiktari.text = canMiktari.ToString();

        if (canMiktari <= 0 || (baslangic_canMiktari - canMiktari) + patlayanBalonSayisi == kacBalonUretilsin)
        {
            // oyunu yeniden başlat
            Buton_YenidenOyna();            
        }
    }

    public void BalonPatlatildi()
    {
        patlayanBalonSayisi++;

        if (patlayanBalonSayisi == kacBalonUretilsin || (baslangic_canMiktari - canMiktari) + patlayanBalonSayisi == kacBalonUretilsin)
        {
            // oyunu yeniden başlat
            Buton_YenidenOyna();
        }
    }

    void BalonUret()
    {
        for (int i = 0; i < kacBalonUretilsin; i++)
        {
            Instantiate(balonPrefab, 
                        new Vector3(Random.Range(-8f, 8f),-10,Random.Range(-2f, 2f)),
                        Quaternion.Euler(90,-90,90)
                        );
        }
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
