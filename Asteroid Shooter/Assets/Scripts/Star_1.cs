using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_1 : MonoBehaviour
{
    public GameObject player;
    public float attractionRange;
    public float attractionForce;
    [SerializeField]
    float distance;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < attractionRange)
        {
            rb.AddForce((player.transform.position - this.transform.position).normalized / distance * attractionForce, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, attractionRange);
        Gizmos.DrawLine(transform.position, player.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerData>().AddToCoinAmount(1);
            Destroy(gameObject);
        }
    }
}
