using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;


public class Oyun4_Card : MonoBehaviour
{
   [SerializeField] private Image iconImage;

   public Sprite hiddenIconSprite;
   public Sprite iconSprite;
   public Oyun4_CardController controller;

   public bool isSelected;

   public void OnCardClick(){
     controller.SetSelected(this);
   }

   public void SetIconSprite(Sprite sp){
      iconSprite = sp;
   } 

   public void Show(){
     Tween.Rotation(transform,new Vector3(0f,180f,0f),0.2f);
     Tween.Delay(0.1f,()=>iconImage.sprite =iconSprite);
     isSelected = true;
   }

   public void Hide(){
    Tween.Rotation(transform,new Vector3(0f,0f,0f),0.2f);
     Tween.Delay(0.1f,()=>{
      iconImage.sprite =hiddenIconSprite;
      isSelected = false;
     });
  
   }
}
