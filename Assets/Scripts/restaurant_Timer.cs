using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class restaurant_Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public static float timeValue = 90;
    public Text timerText;
   


    // Update is called once per frame
    void Update()
    {
        if (restaurant_PlayerMovement.alive == false)
            return;

        if (timeValue > 0)
            timeValue -= Time.deltaTime;
        else
        {
            timeValue = 0;
            restaurant_PlayerMovement.alive = false;
            // restart the game
            restaurant_GroundSpawner.spawn = false;

            Invoke("Restart", 2);
        }

        DisplayTime(timeValue);
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
            timeToDisplay = 0;
        else if (timeToDisplay > 0)
            timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void Restart()
    {
        restaurant_PlayerMovement.Restart();
    }
}
