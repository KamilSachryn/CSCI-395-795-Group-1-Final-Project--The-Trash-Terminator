using UnityEngine;

public class restaurant_GroundTile : MonoBehaviour
{
    restaurant_GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] GameObject kitchenPrefab;
    [SerializeField] GameObject emptyPrefab;
    [SerializeField] float tallObstacleChance = 0.2f;   // want player cannot jump tall obstacle
    [SerializeField] GameObject beerBottle;
    [SerializeField] GameObject cerealBox;
    [SerializeField] GameObject enegryCan;
    [SerializeField] GameObject glass;
    [SerializeField] GameObject cardbordBox;
    [SerializeField] GameObject knife;
    [SerializeField] GameObject plasticSpoon;
    [SerializeField] GameObject plasticFork;
    [SerializeField] GameObject plate;
    [SerializeField] GameObject rottenCheese;
    [SerializeField] GameObject rottenMeat;
    [SerializeField] GameObject tomatoHead;
    [SerializeField] GameObject metalPot;



    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<restaurant_GroundSpawner>(); // since there is only one object type of groundspawner, we can use this to find groundspawner
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (restaurant_PlayerMovement.alive == false)
            return;
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 4);           // destroy the object after 2 secs after the player leave trigger
    }
   
  
    

    public void SpawnObstacle()

    {

        //Choose which obstacle to spawn
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random<tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }
        //choose a random point to spawn obstacles
        int obstacleSpawnIndex = Random.Range(2, 5);    // get number from 2 to 4 inclusive, cuz our obstacle objects are child 2-4 in GroundTile
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //spawn the obstacle at the position
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);     // add "transform" at the end to set its parent, destroy tile along with obstacles

    }

    public void SpawnAssets()
    {
        Transform spawnPoint = transform.GetChild(5).transform;
        
        Instantiate(kitchenPrefab, spawnPoint.position, Quaternion.identity, transform);
    }
    public void SpawnEmptyAssets()
    {
        Transform spawnPoint = transform.GetChild(6).transform;

        Instantiate(emptyPrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        int coinsToSpawn = 1;
        for(int i =0; i< coinsToSpawn; i++)
        {
            GameObject temp;
            int objectSpawn = Random.Range(0, 15);
            if (objectSpawn == 0)
                temp = Instantiate(beerBottle, transform);
            else if (objectSpawn == 1)
                temp = Instantiate(cerealBox, transform);
            else if (objectSpawn == 2)
                temp = Instantiate(enegryCan, transform);
            else if (objectSpawn == 3)
                temp = Instantiate(glass, transform);
            else if (objectSpawn == 4)
                temp = Instantiate(cardbordBox, transform);
            else if (objectSpawn == 5)
                temp = Instantiate(knife, transform);
            else if (objectSpawn == 6)
                temp = Instantiate(plasticSpoon, transform);
            else if (objectSpawn == 7)
                temp = Instantiate(rottenCheese, transform);
            else if (objectSpawn == 8)
                temp = Instantiate(rottenMeat, transform);
            else if (objectSpawn == 9)
                temp = Instantiate(plasticFork, transform);
            else if (objectSpawn == 10)
                temp = Instantiate(plate, transform);
            else if (objectSpawn == 11)
                temp = Instantiate(metalPot, transform);
            else
                temp = Instantiate(tomatoHead, transform);

            
        

             temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Debug.Log(collider.bounds.min.x);
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;                                                                    // coins spawn at some height
        return point;
    }
}
