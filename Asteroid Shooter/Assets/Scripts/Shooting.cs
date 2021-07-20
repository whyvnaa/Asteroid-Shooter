using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject laserPrefab;
    public float speed = 10f;

    private StarshipController starshipController;

    //public float laserForce = 10f;

    public float shootingPeriod = 1f;

    public float destroyDelay = 1.0f;


    void Start(){
        starshipController = this.GetComponent<StarshipController>();
        StartCoroutine(ShootingTimer());
    }


    IEnumerator ShootingTimer() {
        while(!starshipController.isDead)
        {          
            ShootLaser();
            Debug.Log(shootingPeriod);
            yield return new WaitForSeconds(shootingPeriod);
        }
    }

    void ShootLaser()
    {
        Debug.Log(shootingPeriod);
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * speed;
        //rb.AddForce(firePoint.up * laserForce, ForceMode2D.Impulse);
        Object.Destroy(laser, destroyDelay);
    }
}
