using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kod_ButonHarf : MonoBehaviour
{
    public char harf;

    public Transform tr_Arayuz;

    public void ButonaBasildi()
    {
        tr_Arayuz.GetComponent<Kod_KopruGecmece_Arayuz>().Buton_HarfVarMi(harf);

        this.GetComponent<Button>().interactable = false;
    }
}
