using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public GameObject hitEffect;
    public GameObject starPrefab_01;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (GetComponent<Renderer>().isVisible && collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
            Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();           
            asteroid.lifes--;
            if (asteroid.lifes < 1)
            {
                GameObject star = Instantiate(starPrefab_01) as GameObject;
                star.transform.position = collision.transform.position;
                star.GetComponent<Star_1>().player = GameObject.FindGameObjectWithTag("Player"); 
                Destroy(collision.gameObject);
                ScoreScript.scoreValue += asteroid.points;
            } 
        }
        
    }
}
