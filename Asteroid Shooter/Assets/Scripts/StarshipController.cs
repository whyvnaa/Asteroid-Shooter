using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipController : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotationSpeed = 0.01f;
    private Vector2 faceDirection = new Vector2(0,1);

    void Start()
    {
       
    }
    
    void Update()
    {
        faceDirection = GetUnitVectorFromAngle(transform.eulerAngles.z);
        Debug.Log(Mathf.Sin(400*Mathf.PI));
        transform.position = (Vector2)transform.position + faceDirection * speed * Time.deltaTime;

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if(touchPosition.x < 0f)
            {
                transform.Rotate(0, 0, rotationSpeed);
            } else if(touchPosition.x >= 0f)
            {
                transform.Rotate(0, 0, -rotationSpeed);
            }
        }
    }

    private Vector2 GetUnitVectorFromAngle(float alpha)
    {
        float rad = alpha / 360 * 2 * Mathf.PI;
        return new Vector2(Mathf.Cos(rad + Mathf.PI/2), Mathf.Sin(rad + Mathf.PI / 2));
    }
}
