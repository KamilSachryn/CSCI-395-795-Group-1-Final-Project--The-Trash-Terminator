using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ocean_Spawner : MonoBehaviour
{

    [SerializeField] GameObject[] blueTrashPrefab;
    [SerializeField] GameObject[] blackTrashPrefab;
    [SerializeField] GameObject[] greenTrashPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: for final version just get rid of the mesh renderer in prefab
        this.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        SpawnObstacle(); 

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnObstacle()
    {
        //choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(0, 3);
        Transform spawnPoint = this.transform;
        int randomTrash;
        GameObject temp;
        //spawn the obstacle at the position
        if (obstacleSpawnIndex == 0)
        {
            randomTrash = Random.Range(0, greenTrashPrefab.Length);

            temp = Instantiate(greenTrashPrefab[randomTrash], spawnPoint.position, Quaternion.identity, transform);
            var angles = greenTrashPrefab[randomTrash].transform.eulerAngles;
            temp.transform.Rotate(angles.x, angles.y, angles.z);

        }
        else if (obstacleSpawnIndex == 1)
        {
            randomTrash = Random.Range(0, blueTrashPrefab.Length);

            temp = Instantiate(blueTrashPrefab[randomTrash], spawnPoint.position, Quaternion.identity, transform);
            var angles = blueTrashPrefab[randomTrash].transform.eulerAngles;
            temp.transform.Rotate(angles.x, angles.y, angles.z);
        }
        else
        {
            randomTrash = Random.Range(0, blackTrashPrefab.Length);

            temp = Instantiate(blackTrashPrefab[randomTrash], spawnPoint.position, Quaternion.identity, transform);
            var angles = blackTrashPrefab[randomTrash].transform.eulerAngles;
            temp.transform.Rotate(angles.x, angles.y, angles.z);

        }

        //quick workaround to fix issues with prefabs, will fix later
        GreenTrash greenTrash = null;
        BlackTrash blackTrash = null;
        BlueTrash blueTrash = null;
        if (temp.TryGetComponent<GreenTrash>(out greenTrash))
        {
            GreenTrash comp = this.gameObject.AddComponent<GreenTrash>();
            comp.collectSound = greenTrash.collectSound;
            comp.disappearEffect = greenTrash.disappearEffect;
            greenTrash.enabled = false;
        }

        if (temp.TryGetComponent<BlackTrash>(out blackTrash))
        {
            BlackTrash comp = this.gameObject.AddComponent<BlackTrash>();
            comp.collectSound = blackTrash.collectSound;
            comp.disappearEffect = blackTrash.disappearEffect;
            blackTrash.enabled = false;
        }

        if (temp.TryGetComponent<BlueTrash>(out blueTrash))
        {
            BlueTrash comp = this.gameObject.AddComponent<BlueTrash>();
            comp.collectSound = blueTrash.collectSound;
            comp.disappearEffect = blueTrash.disappearEffect;
            blueTrash.enabled = false;
        }



    }

}
