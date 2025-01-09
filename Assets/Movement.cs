using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public AudioSource walk;

    float turnSpeed = 100f;
    float moveSpeed = 5f;

    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
            anim.SetBool("isMoving", true);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -turnSpeed * Time.deltaTime, 0f);
            anim.SetBool("isMoving", true);

        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(moveSpeed * Vector3.forward * Time.deltaTime);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
