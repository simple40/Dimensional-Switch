using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustedButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPressed;
    public float thresholdVelocity = -30f;
    public GameObject platform;
    public AudioSource src;
    public AudioClip sfx1;
    void Start()
    {
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //float yVelMin = 0f; //as velocity is downwards so it will me -ve
        if (other.gameObject.tag == "Player" && !isPressed)
        {
            //Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            //float yVel = rb.velocity.y;
           // yVelMin = Mathf.Min(yVel, yVelMin);
            //Debug.Log("inside trigger: " + yVelMin);
            PlayerScript player = other.GetComponent<PlayerScript>();

            //bool isVelThresholdReached = yVelMin < thresholdVelocity;
            if (player.thresholdVel)
            {
                Debug.Log("rusted button pressed");
                Vector3 newPosition = transform.position;
                newPosition.y -= 0.2f;
                transform.position = newPosition;
                isPressed = true;

                Vector3 newPositionPlatform = platform.transform.localPosition;
                newPositionPlatform.x -= 1f;
                platform.transform.localPosition = newPositionPlatform;
                src.clip = sfx1;
                src.Play();
            }

        }
    }
}
