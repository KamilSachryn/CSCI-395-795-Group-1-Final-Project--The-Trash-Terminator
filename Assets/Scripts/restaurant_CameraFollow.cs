using UnityEngine;

public class restaurant_CameraFollow : MonoBehaviour
{

    [SerializeField] Transform player;                                                
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;            // transform.position refers to the camera's position, cuzwe moved this script under "Main camera" in unity 
                                                                  // this method will allow us to keep the camera the same distance away from the player at all time
    }                                                                   

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos =  player.position + offset;
        targetPos.x = player.position.x;
        transform.position = targetPos;
        //Vector3 temp = transform.position;
        //temp.x = player.position.x;
        //transform.position = temp;
    }
}
