using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody The_rb;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        The_rb.velocity = new Vector3(Input.GetAxis("Horizontal")*moveSpeed, The_rb.velocity.y, Input.GetAxis("Vertical")*moveSpeed);
    }
}
