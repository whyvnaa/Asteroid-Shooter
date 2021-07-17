using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DeployAsteroids;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private float speed;
    void Start()
    {
        speed = GameObject.Find("Main Camera").GetComponent<DeployAsteroids>().averageAsteroidSpeedAtStart + Random.Range(-3, 3);
        //gets reference to the Rigidbody2D Component and sets the speed
        rb = this.GetComponent<Rigidbody2D>();
        //sets velocity towards origin with magnitude speed
        rb.velocity = new Vector2(-rb.transform.position.x, -rb.transform.position.y).normalized * speed;
        rb.angularVelocity = Random.Range(-100, 100);
        //Calculates the rightmost, upmost point of the screen in Worldcoordinates and stores it as a Vector2
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        //Check if Asteroid is far outside of the screen, if yes, it's destroyed. (Possible optimization: Don't check every Frame)
        if(transform.position.x > screenBounds.x*2 || transform.position.x < -screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }
}
