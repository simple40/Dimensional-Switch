using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Button")
        {
           
            //Vector3 newPosition = other.gameObject.transform.position;
            //newPosition.z += 1;
            //transform.position = newPosition;
            rb.isKinematic = true;
        }
    }
}
