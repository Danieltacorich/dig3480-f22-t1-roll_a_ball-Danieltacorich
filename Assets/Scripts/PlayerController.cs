using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public TextMeshProUGUI livesText;  // Check

    private Rigidbody rb;
    private int count;
    private int lives;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;
        SetCountText();

        rb = GetComponent<Rigidbody>(); 

        lives = 3;            // Check 
        SetCountText();

        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gold"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText(); 
        }
        if (other.gameObject.CompareTag("Death"))
        {
            lives = lives - 1;
            transform.position = new Vector3(43.69f, 1.0f, -7.48f);
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 18)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
        }
        // Teleport 1 to LV2
        if (count == 4)
        {
            transform.position = new Vector3(27.0f, 1.0f, -17.0f);
        }
        // Teleport 2 to LV3
        if (count == 10)
        {
            transform.position = new Vector3(43.69f, 1.0f, -7.48f);
        }
        
        livesText.text = "Lives: " + lives.ToString();   //Check
        if (lives == 0)
        {
            loseTextObject.SetActive(true);
            //Destroy(gameObject);
        }
        if (count <= )
    }
        //void SetLivesText()

}