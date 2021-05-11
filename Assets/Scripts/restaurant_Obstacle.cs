using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//kill palyer when collision between player and obstacles
public class restaurant_Obstacle : MonoBehaviour
{
    restaurant_PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<restaurant_PlayerMovement>();
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //kill player
           
            restaurant_PlayerMovement.alive = false;
            restaurant_GroundSpawner.spawn = false;
            Destroy(gameObject);

            Invoke("Restart", 2);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Restart()
    {
        restaurant_PlayerMovement.Restart();
    }
}
