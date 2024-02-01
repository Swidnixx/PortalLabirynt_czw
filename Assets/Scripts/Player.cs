using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float regularSpeed = 7.77f;
    public float fastSpeed = 11.1f;
    public float slowSpeed = 4.5f;
    public float spherecast_radius = 0.5f;
    public LayerMask walkable;

    CharacterController controller;
    float speed = 7.7f;
    float velocity_y;
    bool grounded = true;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");
        Vector3 motion = transform.right * inputx + transform.forward * inputy;
        motion = motion.normalized;
        motion *= speed;
        controller.Move(motion * Time.deltaTime);

        velocity_y += Physics.gravity.y * Time.deltaTime;

        if (velocity_y > 0)
            grounded = false;
        else
            grounded = GroundCheck();

        bool jumpPress = Input.GetButtonDown("Jump");
        if (grounded) //grounded
        {
            if (jumpPress)
                velocity_y = 7;
            else
                velocity_y = 0;
        }
        controller.Move( Vector3.up * velocity_y * Time.deltaTime );
    }

    bool GroundCheck()
    {
        
        Vector3 startPos = transform.position + Vector3.down + Vector3.up * spherecast_radius;
        RaycastHit info;
        bool isGrounded = Physics.SphereCast(startPos, spherecast_radius, Vector3.down, out info, 0.2f, walkable);

        if (!isGrounded)
            return false;

        switch (info.collider.tag)
        {
            case "Fast": 
                speed = fastSpeed; 
                break;
            case "Slow": speed = slowSpeed; break;
            default: speed = regularSpeed; break;
        }

        return isGrounded;
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 startPos = transform.position + Vector3.down + Vector3.up * spherecast_radius;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(startPos, spherecast_radius);
    }
}
