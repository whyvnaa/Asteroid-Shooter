using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarshipController : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotationSpeed = 0.01f;
    private float actualSpeed;
    private Vector2 faceDirection = new Vector2(0,1);

    void Start()
    {
        actualSpeed = speed;
    }
    
    void Update()
    {
        //Stores the direction which the spaceship is facing in a Vector2 and moves the spaceship in that direction
        faceDirection = GetUnitVectorFromAngle(transform.eulerAngles.z);
        transform.position = (Vector2)transform.position + faceDirection * actualSpeed * Time.deltaTime;

        //rotates the spaceship to the right, left depending on which side of the screen is touched
        if(Input.touchCount > 0)
        {
            Touch touch1 = Input.GetTouch(0);
            if (Input.touchCount == 1)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch1.position);
                if(touchPosition.x < 0f)
                {
                    transform.Rotate(0, 0, rotationSpeed);
                } else if(touchPosition.x >= 0f)
                {
                    transform.Rotate(0, 0, -rotationSpeed);
                }
            }
            //if there are two or more touches on the screen, the spaceship stops
            if(Input.touchCount >= 2)
            {
                Touch touch2 = Input.GetTouch(1);
                actualSpeed = 0f;
                if(touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended)
                {
                    actualSpeed = speed; 
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     //   if(collision.gameObject.name == "Asteroid")
       // {
            SceneManager.LoadScene("Main");
            Debug.Log("Hit");
       // }
    }
    //returns a Vector 2 thats rotated alpha degrees from the y-Axis
    private Vector2 GetUnitVectorFromAngle(float alpha)
    {
        float rad = alpha / 360 * 2 * Mathf.PI;
        return new Vector2(Mathf.Cos(rad + Mathf.PI/2), Mathf.Sin(rad + Mathf.PI / 2));
    }
}
