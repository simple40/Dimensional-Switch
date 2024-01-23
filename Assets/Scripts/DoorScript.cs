using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;

    public AudioSource src;
    public AudioClip sfx;

    bool isClosed;
    void Start()
    {
        isClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonScript b1sc = b1.GetComponent<ButtonScript>();
        ButtonScript b2sc = b2.GetComponent<ButtonScript>();
        RustedButtonScript b3sc = b3.GetComponent<RustedButtonScript>();
        if(isClosed && b1sc.isPressed && b2sc.isPressed && b3sc.isPressed)
        {
            Vector3 startPosition = transform.localPosition;
            Vector3 endPosition = startPosition;
            endPosition.y -= 1.5f;
            Vector3 newPosition = Vector3.Lerp(startPosition, endPosition, 2f);
            transform.localPosition = newPosition;
            src.clip = sfx;
            src.Play();
            isClosed = false;
        }
        else
        {
            if (isClosed)
            {
                Vector3 position = transform.localPosition;
                position.y = 2.13F;
                transform.localPosition = position;
            }
            
        }
    }

    
}
