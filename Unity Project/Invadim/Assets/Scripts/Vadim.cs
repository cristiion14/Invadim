using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vadim : MonoBehaviour
{

    float initialHealth = 100f;
    float currentHealth;
    float maxHealth;

    float speed = 10;
    Vector3 velocity;
     void Start()
    {
        currentHealth = initialHealth;
    }

    void Move()
    {
        //the x and y values based on input
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");

        //direction
        velocity = new Vector2(xPos, yPos);


        //applying direction to the position of the player
        transform.position += velocity * speed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, 0, velocity.y);
    }

     void Update()
    {
        Move();
    }




}
