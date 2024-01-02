using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Object")]
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        //If target position on the y axis is greater
        //than the camera position
        if(target.position.y > transform.position.y)
        {
            //The camera will flollow the targets position
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        }

    }
}
