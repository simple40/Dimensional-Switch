using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float frontViewZ = -13f;
    public float frontViewY = 0f;
    public float topViewY = 7f;
    public float topViewZ = 7f;


    private bool isFrontView;

    void Start()
    {
        isFrontView = true;
    }

    // Update is called once per frame
    void Update()
    {
        followTarget();

        if (Input.GetKeyDown(KeyCode.P))
        {
            switchCamera();
        }
    }

    void followTarget()
    {
        if (isFrontView)
        {
            Vector3 desiredPosition = target.position;
            desiredPosition.z = target.position.z + frontViewZ;
            transform.position = desiredPosition;
            
        }
        else
        {
            Vector3 desiredPosition = target.position;
            desiredPosition.y = target.position.y + topViewY;
            desiredPosition.z = target.position.z + topViewZ;
            transform.position = desiredPosition;
        }
    }

    void switchCamera()
    {
        if (isFrontView)
            isFrontView = false;
        else
            isFrontView = true;
    }
}
