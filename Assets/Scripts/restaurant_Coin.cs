using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restaurant_Coin : MonoBehaviour
{

    [SerializeField] float rotateSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        //if (PlayerMovement.alive == false)
         //   return;

        if(other.gameObject.GetComponent<restaurant_Obstacle>() != null)        //To fix some coin spawn inside the obstacles
        {
            Destroy(gameObject);
            return;
        }
        
        // Check object we collide with is the player
        if (other.gameObject.name != "Player")
        {
            return;
        }

       

        // Add the player's score

        bool correct = false;
        Debug.Log(transform.gameObject.name);

        if (other.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.activeSelf && (transform.gameObject.name == "Rotten_cheese(Clone)" || transform.gameObject.name == "Rotten_Meat(Clone)" || transform.gameObject.name == "TomatoHead_169_Tris_(Clone)"))
        {
            correct = true;
            Destroy(gameObject);
        }
        else if (other.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.activeSelf && (transform.gameObject.name == "CerealBox_Mid__400_Tris_(Clone)" || transform.gameObject.name == "CarboardBox_1(Clone)"))
        {
            correct = true;
            Destroy(gameObject);
        }
        else if (other.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.activeSelf && (transform.gameObject.name == "Plastic Spoon(Clone)" || transform.gameObject.name == "Plastic Spork(Clone)" || transform.gameObject.name == "Plate3(Clone)"))
        {
            correct = true;
            Destroy(gameObject);
        }
        else if (other.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.activeSelf && (transform.gameObject.name == "KnifeKitchen(Clone)" || transform.gameObject.name == "Pan(Clone)" || transform.gameObject.name == "EnergyDrink_Mid__226_Tris_(Clone)" || transform.gameObject.name == "Glass(Clone)"  || transform.gameObject.name == "BeerBottle_Mid__620_Tris_(Clone)")  )
        {
            correct = true;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //-------------------------


       

        if (correct == true)
        {
            restaurant_GameManager.inst.IncreaseScore();
            restaurant_SoundManager.PlaySound("good");
        }
        else
        {
            restaurant_GameManager.inst.DecreaseScore();
            restaurant_SoundManager.PlaySound("bad");
        }


        // Destory the coin
        




    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0,  rotateSpeed * Time.deltaTime,0);  // coin will always rotate 90 degrees every second regardless of framerate
       
    }
}
