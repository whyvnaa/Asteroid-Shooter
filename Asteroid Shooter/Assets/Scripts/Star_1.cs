using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_1 : MonoBehaviour
{
    public GameObject player;
    public float attractionRange;
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
        {
            rb.((player.transform.position - this.transform.position).normalized / (Mathf.Pow(distance, 2)));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, attractionRange);
        Gizmos.DrawLine(transform.position, player.transform.position);
    }
}
