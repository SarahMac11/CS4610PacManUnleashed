﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

        moveSpeed=10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,  0f  ,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);   

        //print(Input.GetAxis("Horizontal"));     
    }
}
