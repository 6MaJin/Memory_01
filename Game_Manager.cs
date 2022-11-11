using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public AudioSource audioSource;

    public MemoryCard firstSelectedCard;
    public MemoryCard secondSelectedCard;

    public bool canClick = true;
    public bool canClickFirstCard = true;

    public AudioClip clipCardUp;
    public AudioClip clipCardDown;
    public AudioClip clipCardMatch;

    public void CardClicked(MemoryCard card) {

        if(canClick == false) {
            return;
        }

        //rotate card up
        card.targetRotation = 90;
        card.targetHeight = 0.1f;

        

        if(firstSelectedCard == null) {
            firstSelectedCard = card;
            canClickFirstCard = false;
            audioSource.PlayOneShot(clipCardUp);
        }
        else {
            if(firstSelectedCard != null)  {
                 secondSelectedCard = card;
                 audioSource.PlayOneShot(clipCardUp);
            }
           
            canClick = false;

            Invoke("CheckMatch", 1);

        }
        
    }
    public void CheckMatch() {
        if(firstSelectedCard.id == secondSelectedCard.id ) {
                if(firstSelectedCard.name != secondSelectedCard.name) {
                    Destroy(firstSelectedCard.gameObject);
                    Destroy(secondSelectedCard.gameObject);
                    audioSource.PlayOneShot(clipCardMatch);
                }
             

            }
            else {
                firstSelectedCard.targetRotation = -90;
                secondSelectedCard.targetRotation = -90;
                firstSelectedCard.targetHeight = 0.01f;

                secondSelectedCard.targetHeight = 0.01f;
                audioSource.PlayOneShot(clipCardUp);
                firstSelectedCard = null;
                secondSelectedCard = null;
            }


            
            canClickFirstCard = true;
            canClick = true;
    }    

}