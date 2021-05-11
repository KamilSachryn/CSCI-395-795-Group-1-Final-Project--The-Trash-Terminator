using UnityEngine;

public class park_Obstacle : MonoBehaviour
{
    private bool hasEntered;

    private void OnCollisionEnter(Collision other)
    {
        if (!hasEntered && (other.gameObject.name == "Player" || other.transform.parent.name == "TrashBinHolder"))
        {
            hasEntered = true;
            park_GameManager.inst.LoseLife();
            FindObjectOfType<park_AudioManager>().PlaySound("Incorrect");
        }
    }
}
