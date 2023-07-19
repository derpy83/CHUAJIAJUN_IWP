using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentpoint;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentpoint = pointB.transform;
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentpoint.position - transform.position;
        if(currentpoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position,currentpoint.position)< 0.5f && currentpoint == pointB.transform)
        {
            flip();
            currentpoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentpoint.position) < 0.5f && currentpoint == pointA.transform)
        {
            flip();
            currentpoint = pointB.transform;
        }
    }

    private void flip()
    {
        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
