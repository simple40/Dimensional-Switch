using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool isTriggered;
    public bool isPressed;
    bool boxPress;
    public AudioSource src;
    public AudioClip sfx1;
    public AudioClip sfx2;


    void Start()
    {
        isTriggered = false;
        isPressed = false;
        boxPress = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //if((other.gameObject.tag == "Player" || other.gameObject.tag == "Box")  && !isTriggered)
        //{
        //    Debug.Log("button pressed first time");
        //    //Vector3 newPosition = transform.position;
        //    //newPosition.y -= 0.2f;
        //    //transform.position = newPosition;
        //    //isTriggered = true;
        //}
        if((other.gameObject.tag == "Player" || other.gameObject.tag == "Box" ) && !isPressed)
        {
            Debug.Log("button pressed");
            Vector3 newPosition = transform.position;
            newPosition.y -= 0.2f;
            transform.position = newPosition;
            //isTriggered = true;
            isPressed = true;
            src.clip = sfx1;
            src.Play();
        }
        if(other.gameObject.tag == "Box")
        {
            boxPress = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!boxPress)
        {
            Debug.Log("button reset");
            Vector3 newPosition = transform.position;
            newPosition.y += 0.2f;
            transform.position = newPosition;
            isPressed = false;
            src.clip = sfx2;
            src.Play();
        }
    }
}
