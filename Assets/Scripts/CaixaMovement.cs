﻿using UnityEngine;

public class CaixaMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public ParticleSystem particles;
    public float moveSpeed = 5f;

    private bool sparking = false;
    private bool condition = false;
    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
	        condition = true;
	    }	
    } 
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
	        condition = false;
	    }
    }
    
    private void FixedUpdate()
    {   
    	if (Input.GetKey("space") && condition)
    	{
        	rigidBody.MovePosition(rigidBody.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
            if (!sparking)
            {
                particles.Play();
                sparking = true;
            }
        }
        else if (sparking)
        {
            particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            sparking = false;
        }
    }
}
