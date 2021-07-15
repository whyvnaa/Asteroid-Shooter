using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject laserPrefab;

    public float laserForce = 10f;

    public float shootingPeriod = 0.2f;


    void Start(){
        StartCoroutine("ShootingTimer");
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

}
