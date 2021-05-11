using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class school_collectTrash : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
 
        if(other.tag =="trash")
            school_LidAnimation.animate = true;
        

    }
}
