﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class school_Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    public AudioClip collectSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<school_Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        
        //check that the object we collided with is the player
        if(other.gameObject.name != "Player")
        {
            return;
        }
        // add to the player's score
        school_GameManager.inst.IncrementScore();
        // play audio
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        
        //destroy this coin object
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
