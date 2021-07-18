using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
            Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();           
            asteroid.lifes--;
            if (asteroid.lifes < 1)
            {
                Destroy(collision.gameObject);
                ScoreScript.scoreValue += 1;
            }
                     
            
        }
        
    }
}
