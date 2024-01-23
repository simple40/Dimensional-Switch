using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitchScript : MonoBehaviour
{
    bool isFrontView;
    // Start is called before the first frame update
    
    void Start()
    {
        isFrontView = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            switchPlatform();
        }

    }

    void switchPlatform()
    {
        if (isFrontView)
        {
            Vector3 resetRotation = new Vector3(90, 0, 0);
            Vector3 newRotation = new Vector3(0, 90, 0);
            transform.Rotate(resetRotation);
            transform.Rotate(newRotation);
            isFrontView = false;
        }
        else
        {
            Vector3 resetRotation = new Vector3(0, -90, 0);
            Vector3 newRotation = new Vector3(-90, 0, 0);
            transform.Rotate(resetRotation);
            transform.Rotate(newRotation);
            isFrontView = true;
        }
    }
}
