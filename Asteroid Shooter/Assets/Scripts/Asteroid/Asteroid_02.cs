using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_02 : Asteroid
{

    void Start()
    {

        speed = avgSpeed * (GameObject.Find("Main Camera").GetComponent<DeployAsteroids>().averageAsteroidSpeedAtStart + Random.Range(-3, 3));
        //gets reference to the Rigidbody2D Component and sets the speed
        rb = this.GetComponent<Rigidbody2D>();
        //sets velocity towards origin with magnitude speed
        rb.velocity = new Vector2(-rb.transform.position.x, -rb.transform.position.y).normalized * speed;
        rb.angularVelocity = Random.Range(-100, 100);
        //Calculates the rightmost, upmost point of the screen in Worldcoordinates and stores it as a Vector2
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

}
