using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    //Rigidbody 2D that is stored
    [Header("Rigidbody")]
    public Rigidbody2D rb;
    [Header("Default Down Speed")]
    //Downward speed of the object
    public float downSpeed = 20f;
    [Header("Default Movement Speed")]
    //Movement speed of the object
    public float movementSpeed = 10f;
    [Header("Default Directional Movement Speed")]
    //Movement direction of the object
    public float movement = 0f;

    [Header("score text")]
    public Text scoreText;

    //score of game
    private float topScore = 0.0f;

   
    // Start is called before the first frame update
    void Start()
    {
        //variable equals to component Rigidbdy 2D
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //Movement equals horizontal movement
        //multiplied by the movement speed
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        //If direction on x axis is less than 0
        if (movement < 0)
        {
            //Object faces to the left
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        //If direction on x axis is greater than 0
        else
        {
            //object faces to the right
            this.GetComponent<SpriteRenderer>().flipX = true;

        }

        //If players velocity is greater than 0
        //and pos on the ya axis is greater
        //than the score
        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            //Score equals players position
            topScore = transform.position.y;
        }
        //Text for the score equals to the top score
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
    }

    //Fixed update called every fixed frame rate
    void FixedUpdate()
    {
        //Vector 2 which is x,y  velocity
        //equals to the velocity of the rigid body 2D
        Vector2 velocity = rb.velocity;
        //Velocity of the x axis equals to
        //the direction movement of the x axis
        // of the character
        velocity.x = movement;
        //Rigidbody2D velocity equals to 
        //velocity of the object
        rb.velocity = velocity;
    }

    //Collision function
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //velocity with the downspeed
        rb.velocity = new Vector3(rb.velocity.x, downSpeed, 0);
    }

}
