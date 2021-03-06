using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class school_GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
    
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        if (spawnItems)
        {
            temp.GetComponent<school_GroundTile>().SpawnObstacle();
           // temp.GetComponent<GroundTile>().SpawnBlackTrash();
           // temp.GetComponent<GroundTile>().SpawnCoins();
          //  temp.GetComponent<GroundTile>().SpawnBlueTrash();
          //  temp.GetComponent<GroundTile>().SpawnGreenTrash();


        }
    }
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
                SpawnTile(true);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
