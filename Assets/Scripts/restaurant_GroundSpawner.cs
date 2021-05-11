using UnityEngine;

public class restaurant_GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;
    private float nextActionTime = 0.0f;
    public static bool spawn = false;


    public void SpawnTile(bool spawnItems)
    {
        if (restaurant_PlayerMovement.alive == false)
            return;
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);  //Instantiate is how we spawn (make more) object in unity, 
                                                                                         // first argument is object we wnat to spawn,
                                                                                         //second argument is where we want to spawn
                                                                                         // third one, determine the rotation
                                                                                         //Quaternion.identity means no rotation

        nextSpawnPoint = temp.transform.GetChild(1).transform.position;             // GroundTile has 2 children, Plane and NextSpawnPoint
                                                                                    // we want the second child


        int assetType = Random.Range(0, 5);

        if (assetType == 3)
            temp.GetComponent<restaurant_GroundTile>().SpawnAssets(); 
        else
            temp.GetComponent<restaurant_GroundTile>().SpawnEmptyAssets();
            
        

        if (spawnItems)
        {

            temp.GetComponent<restaurant_GroundTile>().SpawnCoins();

        }
        if (spawnItems && spawn == true)
        {
            temp.GetComponent<restaurant_GroundTile>().SpawnObstacle();
            
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }else if (i == 15)
            {
                spawn = true;
            }
            else
            {
                SpawnTile(true);
            }
        }
        
    }

   
}
