using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class school_Obstacle : MonoBehaviour
{
    school_PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<school_PlayerMovement>();
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            playerMovement.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
