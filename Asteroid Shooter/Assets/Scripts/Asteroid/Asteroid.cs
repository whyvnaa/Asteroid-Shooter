using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DeployAsteroids;

public abstract class Asteroid : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 screenBounds;
    public float speed;

    public int lifes;
    public float avgSpeed;
    public int points;

    void Update()
    {
        //Check if Asteroid is far outside of the screen, if yes, it's destroyed. (Possible optimization: Don't check every Frame)
        if (transform.position.x > screenBounds.x * 2 || transform.position.x < -screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }
}
