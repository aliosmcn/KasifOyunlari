using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oyun4_CardController : MonoBehaviour
{

     [SerializeField] Oyun4_Card cardPrefab;
     [SerializeField] Transform gridTransform;
     [SerializeField] Sprite[] sprites;

     [SerializeField] TMP_Text timerText;
     [SerializeField] Button pauseButton;

     private List<Sprite> spritePairs;

     Oyun4_Card firstSelected;
     Oyun4_Card secondSelected;

     int matchCounts;

     private float gameTime = 0f;
     private bool isPaused = false;

    private void Start()
    {
         PrepairSprites();
         CreateCards();

         StartCoroutine(UpdateTimer());
         pauseButton.onClick.AddListener(PauseTrigger);
    }


    private void PrepairSprites(){
      spritePairs = new List<Sprite>();
      for(int i=0; i<sprites.Length;i++){
         
         spritePairs.Add(sprites[i]);
         spritePairs.Add(sprites[i]);
      }
      ShuffleSprites(spritePairs);
    }

    void CreateCards(){
        for(int i=0; i<spritePairs.Count;i++){
         Oyun4_Card card = Instantiate(cardPrefab,gridTransform);
         card.SetIconSprite(spritePairs[i]);
         card.controller = this;
        }
    }

    public void SetSelected(Oyun4_Card card){
        if ( isPaused) return;
         if (card.isSelected == false){
             card.Show();

             if(firstSelected == null){
                firstSelected =card;
                return;
             }

             if(secondSelected == null){
                secondSelected = card;
                StartCoroutine(CheckMaching(firstSelected,secondSelected));
                firstSelected = null;
                secondSelected = null;
             }
         }
    }

    IEnumerator CheckMaching(Oyun4_Card a, Oyun4_Card b){
        yield return new WaitForSeconds(0.3f);
        if(a.iconSprite== b.iconSprite){
         
         matchCounts++;
         if(matchCounts>=spritePairs.Count/2){
            PrimeTween.Sequence.Create().Chain(PrimeTween.Tween.Scale(gridTransform,Vector3.one*1.2f,0.2f,ease: PrimeTween.Ease.OutBack))
            .Chain(PrimeTween.Tween.Scale(gridTransform,Vector3.one,0.1f));
         }

        }else{
            a.Hide();
            b.Hide();
        }
    }

    private void ShuffleSprites(List<Sprite> spriteList)
    {
        for(int i = spriteList.Count -1; i > 0; i--){
             int randomIndex = Random.Range(0,i+1);
              
             Sprite temp = spriteList[i];
             spriteList[i] = spriteList[randomIndex];
             spriteList[randomIndex] = temp;
        }
    }

    IEnumerator UpdateTimer()
    {
        while (true)
        {
            if (!isPaused)
            {
                gameTime += Time.deltaTime;
                UpdateTimerDisplay();
            }
            yield return null;
        }
    }

    void UpdateTimerDisplay()
    {
       int seconds = Mathf.FloorToInt(gameTime); 
       timerText.text=seconds.ToString();
    }

    public void PauseTrigger()
    {
        isPaused = !isPaused;
        pauseButton.GetComponentInChildren<TMP_Text>().text = isPaused ? "Devam" : "Durdur";
    }


   public void ReturnToMenu()
    {
        SceneManager.LoadScene("Ana Sahne"); 
    }

   public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
