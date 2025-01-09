using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundBox : MonoBehaviour
{
    public GameObject coins;
    public GameObject particle;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Treasure")
        {
            Destroy(other.gameObject);
            effect();
            GameController.score++;

            
        }

    }
    void effect()
    {
        Instantiate(coins, transform.position + transform.forward, Quaternion.identity);
        Instantiate(particle, transform.position + transform.forward, Quaternion.identity);
    }
}