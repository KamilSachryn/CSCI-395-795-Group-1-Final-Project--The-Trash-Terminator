using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class school_GameManager : MonoBehaviour
{
    public int score;
    public static school_GameManager inst;
    [SerializeField] Text scoreText;
 

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        //increase player's speed
       // playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }
 
    private void Awake()
    {
        inst = this;
    }
   
  
}
