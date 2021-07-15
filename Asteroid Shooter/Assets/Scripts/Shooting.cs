using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject laserPrefab;

    public float laserForce = 10f;

    public float shootingPeriod = 0.2f;

    public float destroyDelay = 1.0f;


    void Start(){
        StartCoroutine("ShootingTimer");
    }


    IEnumerator ShootingTimer() {
        while(true){          
            ShootLaser();
            yield return new WaitForSeconds(shootingPeriod);
        }
    }

    void ShootLaser()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * laserForce, ForceMode2D.Impulse);
        Object.Destroy(laser, destroyDelay);
    }
}
