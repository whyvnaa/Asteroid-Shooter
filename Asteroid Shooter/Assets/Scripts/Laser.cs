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
            Destroy(collision.gameObject);
            ScoreScript.scoreValue += 1;
        }
        
    }
}
