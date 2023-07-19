using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : MonoBehaviour
{
    public DetectionZone attackzone;
    
    Animator anim;
    Rigidbody2D rb;
    public float flightSpeed = 2f;
    public float waypointReachedDistance = 0.1f;
    public List<Transform> waypoints;

    Transform nextWaypoint;
    int waypointNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        nextWaypoint = waypoints[waypointNum];
    }

    // Update is called once per frame
    void Update()
    {
        HasTarget = attackzone.detectedColliders.Count > 0;
    }

    public bool _hastarget = false;
    public bool HasTarget
    {
        get { return _hastarget; }
        private set
        {
            _hastarget = value;
            anim.SetBool(AnimationStrings.hasTarget, value);
        }
    }
    public bool CanMove
    {
        get
        {
            return anim.GetBool(AnimationStrings.canMove);
        }
    }
    private void Flight()
    {
        // Fly to next waypoint
        Vector2 directionToWaypoint = (nextWaypoint.position - transform.position).normalized;

        // Check if we have reached the waypoint already
        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        rb.velocity = directionToWaypoint * flightSpeed;
        UpdateDirection();

        // See if we need to switch waypoints
        if (distance <= waypointReachedDistance)
        {
            // Switch to next waypoint
            waypointNum++;

            if (waypointNum >= waypoints.Count)
            {
                // Loop back to original waypoint
                waypointNum = 0;
            }

            nextWaypoint = waypoints[waypointNum];
        }
    }
    private void FixedUpdate()
    {
        if (CanMove)
        {
            Flight();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void UpdateDirection()
    {
        Vector3 locScale = transform.localScale;

        if (transform.localScale.x > 0)
        {
            // Facing the right
            if (rb.velocity.x < 0)
            {
                // Flip
                transform.localScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
            }
        }
        else
        {
            // Facing the Left
            if (rb.velocity.x > 0)
            {
                // Flip
                transform.localScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
            }
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //touchingdirections = GetComponent<TouchingDirections>();
        anim = GetComponent<Animator>();
    }
}
