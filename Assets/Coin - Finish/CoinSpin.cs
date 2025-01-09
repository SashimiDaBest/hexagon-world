using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    float turnSpeed = 300f;
    float flySpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f , flySpeed * Time.deltaTime , -turnSpeed * Time.deltaTime);
        transform.Translate(5f * Vector3.up * Time.deltaTime);
        Destroy(this.gameObject, 10f);
    }
}
