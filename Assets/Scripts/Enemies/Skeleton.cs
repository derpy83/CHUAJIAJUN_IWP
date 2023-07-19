using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float speed = 3f;
    Rigidbody2D rb;
    TouchingDirections touchingdirections;
    public DetectionZone attackzone;
    Animator anim;

    public enum walkDirection { Right, Left}
    private walkDirection _walkDirection;
    private Vector2 Directionvector = Vector2.right;
    public float walkStopRate = 0.6f;
    public walkDirection WalkDirection
    {
        get { return _walkDirection; }
        set { 
            if(_walkDirection != value)
            {
                //Fipped
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                if(value == walkDirection.Right)
                {
                    Directionvector = Vector2.right;
                }else if(value == walkDirection.Left)
                {
                    Directionvector = Vector2.left;
                }
            }
            
            
            _walkDirection = value; }
    }

    public bool _hastarget = false;
    public bool HasTarget { 
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
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingdirections = GetComponent<TouchingDirections>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        HasTarget = attackzone.detectedColliders.Count > 0;
    }
    private void FixedUpdate()
    {
        if (touchingdirections.IsGrounded && touchingdirections.IsOnWall)
        {
            Flip();
        }
        if (CanMove)
            rb.velocity = new Vector2(speed * Directionvector.x, rb.velocity.y);
        else
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x,0,walkStopRate), rb.velocity.y);
    }

    private void Flip()
    {
        if (WalkDirection == walkDirection.Right)
        {
            WalkDirection = walkDirection.Left;
        }
        else if(WalkDirection == walkDirection.Left)
        {
            WalkDirection = walkDirection.Right;
        }
    }

    public void onCliffDetect()
    {
        if (touchingdirections.IsGrounded)
        {
            Flip();
        }
    }
}
