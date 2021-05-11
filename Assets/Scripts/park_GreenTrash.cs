﻿using UnityEngine;

public class park_GreenTrash : MonoBehaviour
{
    public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        // check that the object we collided is a trash bin
        if (other.gameObject.name == "Player" || other.transform.parent.name != "TrashBinHolder")
            return;

        // add to the player's score
        if (other.transform.name == "TrashBinGreen")
        {
            park_GameManager.inst.IncrementScore();
            FindObjectOfType<park_AudioManager>().PlaySound("Correct");
        }
        else
        {
            park_GameManager.inst.DecrementScore();
            FindObjectOfType<park_AudioManager>().PlaySound("Incorrect");
        }

        // destroy this coin object
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
