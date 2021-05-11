using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class park_GameOverScreen : MonoBehaviour
{
    public static park_GameOverScreen inst;
    public Canvas gameOverScreen;
  
    public void Setup()
    {
        gameOverScreen.enabled = true;
    }
}
