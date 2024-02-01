using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float speed = 400;
    Transform player;
    float rotX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player = transform.parent;
    }

    private void Update()
    {
        float mousex = Input.GetAxis("Mouse X");
        player.Rotate(Vector3.up * mousex * Time.deltaTime * speed);

        float mousey = Input.GetAxis("Mouse Y");
        rotX -= mousey * Time.deltaTime * speed;
        rotX = Mathf.Clamp(rotX, -90, 60);
        transform.localRotation = Quaternion.Euler(rotX, 0, 0);
    }
}
