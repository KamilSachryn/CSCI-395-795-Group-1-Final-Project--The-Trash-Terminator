using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    

    public Text scoreText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "SCORE: " + score.ToString();
    }
    public void hide()
    {
        gameObject.SetActive(false);

    }
   
    public void ExitButton()
    {

    }
}
