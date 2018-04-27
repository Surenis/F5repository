 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Cameras;

public class PlayerControler : NetworkBehaviour
{
	public float walkSpeed = 8f;
    public float jumpSpeed = 7f;
    Rigidbody rb;
    Collider coll;
    bool pressedJump = false;
    
   
    
 
    public Vector2 savedVelocity;
    
    
 
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        if (isLocalPlayer)
        {
            Camera.main.transform.position =
                this.transform.position - this.transform.forward * 8 + this.transform.up *3 ;
            Camera.main.transform.LookAt(this.transform.position);
            Camera.main.transform.parent = this.transform;
        }
    }
	
	
	void Update ()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        WalkHandler();
        JumpHandler();
        
    }
 

    void WalkHandler()
    {
        // Set x and z velocities to zero
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
 
        // Distance ( speed = distance / time --> distance = speed * time)
        float distance = walkSpeed * Time.deltaTime;
 
        // Input on lateral mvt ("Sidestep")
        float hAxis = Input.GetAxis("Sidestep");
 
        // Input on z ("Vertical")
        float vAxis = Input.GetAxis("Vertical");

        // Input on x ("Horizontal mouvement")
        float rotate = Input.GetAxis("Horizontal");

        //Vector associated to the angle rotation
        Vector3 AngleVelocity = new Vector3(0, rotate * 3f, 0);
        
        rb.transform.Translate(hAxis* 8f * Time.deltaTime, 0, vAxis * 8* Time.deltaTime);
        
        //rotate the rigidbody
        rb.transform.Rotate(AngleVelocity);
        
    }
 
    // Check whether the player can jump and make it jump
    void JumpHandler()
    {
        
        float jAxis = Input.GetAxis("Jump");
 
        
        bool isGrounded = CheckGrounded();
 
        // Check if the player is pressing the jump key
        if (jAxis > 0f)
        {
            // Make sure we've not already jumped on this key press
            if(!pressedJump && isGrounded)
            {
                // We are jumping on the current key press
                pressedJump = true;
 
                // Jumping vector
                Vector3 jumpVector = new Vector3(0f, jumpSpeed, 0f);
 
                // Make the player jump by adding velocity
                rb.velocity = rb.velocity + jumpVector;
            }            
        }
        else
        {
            // Update flag so it can jump again if we press the jump key
            pressedJump = false;
        }
    }
 
    
    bool CheckGrounded()
    {
        // Object size in x
        float sizeX = coll.bounds.size.x;
        float sizeZ = coll.bounds.size.z;
        float sizeY = coll.bounds.size.y;
 
        // Position of the 4 bottom corners of the game object
        // We add 0.01 in Y so that there is some distance between the point and the floor
        Vector3 corner1 = transform.position + new Vector3(sizeX/2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner2 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner3 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);
        Vector3 corner4 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);
 
        // Send a short ray down the cube on all 4 corners to detect ground
        bool grounded1 = Physics.Raycast(corner1, new Vector3(0, -1, 0), 0.01f);
        bool grounded2 = Physics.Raycast(corner2, new Vector3(0, -1, 0), 0.01f);
        bool grounded3 = Physics.Raycast(corner3, new Vector3(0, -1, 0), 0.01f);
        bool grounded4 = Physics.Raycast(corner4, new Vector3(0, -1, 0), 0.01f);
 
        // If any corner is grounded, the object is grounded
        return (grounded1 || grounded2 || grounded3 || grounded4);
    }
	

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<AutoCam>().SetTarget(gameObject.transform);
    }

   
    
}
