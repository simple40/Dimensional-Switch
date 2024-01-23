using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButtonBoxScript : MonoBehaviour
{
    //Start is called before the first frame update
    public GameObject boxGameObject;
    public GameObject mainPlatform;
    public float thresholdVelocity = -10;
    public bool isPressed;
    public bool isTriggered;
    public AudioSource src;
    public AudioClip sfx;
    void Start()
    {
        isPressed = false;
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        //if(other.gameObject.tag == "Player" && !isPressed )
        //{
        //    Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        //    float yVel = rb.velocity.y;
        //    Debug.Log("inside trigger: " + yVel);
        //    PlayerScript player = other.GetComponent<PlayerScript>();
            
        //    bool isVelThresholdReached = yVel < thresholdVelocity;
        //    if (isVelThresholdReached)
        //    {
        //        Vector3 newPosition = new Vector3(-114f, 4, -12);
        //        //newPosition.z += 5f;
        //        GameObject newBox2 = Object.Instantiate(boxGameObject, new Vector3(0, 0, 0), Quaternion.identity);
        //        newBox2.transform.parent = mainPlatform.transform;
        //        newBox2.transform.localPosition = newPosition;
        //        isPressed = true;
        //    }
            
        //}

        if (!isTriggered && other.gameObject.tag == "Player")
        {


            Debug.Log("lower button pressed");
            Vector3 newPosition = transform.position;
            newPosition.y -= 0.2f;
            transform.position = newPosition;
            isTriggered = true;

            newPosition = new Vector3(-113f, 4, 24);
            //newPosition.z += 5f;
            GameObject newBox = Object.Instantiate(boxGameObject, new Vector3(0, 0, 0), Quaternion.identity);
            newBox.transform.parent = mainPlatform.transform;
            newBox.transform.localPosition = newPosition;

            newPosition = new Vector3(-90f, 4, -12);
            //newPosition.z += 5f;
            GameObject newBox2 = Object.Instantiate(boxGameObject, new Vector3(0, 0, 0), Quaternion.identity);
            newBox2.transform.parent = mainPlatform.transform;
            newBox2.transform.localPosition = newPosition;

            src.clip = sfx;
            src.Play();
        }
    }

    public void SpawnBox(Vector3 position)
    {
        GameObject mainPlatform = GameObject.Find("MainPlatform");
        GameObject box = GameObject.Find("Box");
        GameObject newBox = Object.Instantiate(box, new Vector3(0, 0, 0), Quaternion.identity);
        newBox.transform.parent = mainPlatform.transform;
        newBox.transform.localPosition = position;
    }
}
