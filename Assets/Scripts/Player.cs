using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 7.7f;
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    float velocity_y;
    bool grounded = true;
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

    public float spherecast_radius = 0.5f;
    public LayerMask walkable;
    bool GroundCheck()
    {
        
        Vector3 startPos = transform.position + Vector3.down + Vector3.up * spherecast_radius;
        RaycastHit info;
        return Physics.SphereCast(startPos, spherecast_radius, Vector3.down, out info, 0.2f, walkable);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 startPos = transform.position + Vector3.down + Vector3.up * spherecast_radius;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(startPos, spherecast_radius);
    }
}
