using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 10f;
    public float gravityScale = 1.0f;
    private Rigidbody rb;
    private bool isGrounded;
    public bool flipped = false;
    public bool isFrontView;
    private bool previousGrounded;
    public float fallThresholdVelocity = 40f;
    public bool thresholdVel;
    public AudioSource src;
    public AudioClip sfx;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isFrontView = true;
        thresholdVel = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        previousGrounded = isGrounded;
        checkIsGrounded();
        checkFallVelocity();
        if (isGrounded && Input.GetButtonDown("Jump") && isFrontView)
        {    
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            switchPlayer();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            restart();
        }
    }




    void MovePlayer()
    {
        if (isFrontView)
        {
            float x = Input.GetAxisRaw("Horizontal");
            if (x != 0)
            {
                if (x > 0)
                {
                    if (gameObject.transform.localScale.x < 0)
                    {
                        flip();
                    }
                }
                else
                {
                    if (gameObject.transform.localScale.x > 0)
                    {
                        flip();
                    }
                }
                Vector3 targetVelocity = new Vector2(x * movementSpeed, rb.velocity.y);
                rb.velocity = targetVelocity;
            }
        }
        else
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            Vector3 targetVelocity = new Vector3(x * movementSpeed, rb.velocity.y , y*movementSpeed);
            rb.velocity = targetVelocity;
        }
    }

    private void moveCharacter(float x, float y)
    {
        Vector3 targetVelocity = new Vector2(x * movementSpeed, rb.velocity.y);

        //player.velocity = Vector3.SmoothDamp(player.velocity, targetVelocity, ref m_velocity, m_MovementSmoothing);
        rb.velocity = targetVelocity;
    }

    void Jump()
    {
        Debug.Log("jump");
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        rb.velocity = Vector3.up * jumpForce;
    }

    void flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        if (flipped)
            flipped = false;
        else
            flipped = true;
    }

    void switchPlayer()
    {
        if (isFrontView)
        {
            transform.Rotate(-90, 0, 0);
            isFrontView = false;
            src.clip = sfx;
            src.Play();
        }
        else
        {
            transform.Rotate(90, 0, 0);
            Vector3 currentPosition = transform.localPosition;
            currentPosition.y = 3.8f; // Replace newYPosition with your desired value
            transform.localPosition = currentPosition;

            isFrontView = true;
            src.clip = sfx;
            src.Play();
        }
        
    }

    void checkIsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1f)) 
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void checkFallVelocity()
    {
        if(!previousGrounded && isGrounded)
        {
            if(rb.velocity.y < fallThresholdVelocity)
            {
                Debug.Log("high velocity " + rb.velocity.y);
                thresholdVel = true;
            }
            else
            {
                Debug.Log("not enough velocity " + rb.velocity.y);
                thresholdVel = false;
            }
        }
    }

    void restart()
    {
        SceneManager.LoadScene("Level1");
    }

}

//complete the rusted button using events
//cube 2 glitch solve by fixing its origin or remove it and place new there
//make the exit 
//make the menu 
//add some sound effects
//add the tutorials


