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

    void Update()
    {
        float inputx = Input.GetAxis("Horizontal");
        controller.Move( new Vector3(inputx, 0, 0) * speed * Time.deltaTime );
    }
}
