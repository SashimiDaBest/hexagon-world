using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
    float thrust = 100f;
    float forward = 200f;
    bool moving = false;
    float forceTime;
    float forceInterval = 0.5f;

    Animator Test1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forceTime = Time.time;
        Test1 = GetComponent<Animator>();
    }

    void Update()
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);
        if (dis < 5f && Time.time > forceTime + forceInterval)
        {
            Vector3 dir = player.transform.position - transform.position;
            dir = new Vector3(dir.x, 0, dir.z);
            transform.rotation = Quaternion.LookRotation(dir);
            moving = true;
            Test1.SetBool("isClose", true);
        }
        else
        {
            Test1.SetBool("isClose", false);
        }
    }

    void FixedUpdate()
    {
        if (moving)
        {
            rb.AddForce(transform.up * thrust);
            rb.AddRelativeForce(Vector3.forward * forward);
            forceTime = Time.time;
            moving = false;
        }
    }

}
