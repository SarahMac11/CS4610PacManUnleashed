using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PManControl : MonoBehaviour
{

    public float moveSpeed;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    public CharacterController controller;
    void Start(){
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        //moveDirection=(transform.foward * Input.GetAxis("Vertical"));
        moveDirection = new Vector3(Input.GetAxis("Horizontal")*moveSpeed, 0f, Input.GetAxis("Vertical")*moveSpeed);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y = 0f;
    }
}
