using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public float moveSpeed;
    public float ghostSpeed = 0f;
    public float MovementSpeed = 0f;
    public Rigidbody The_rb;
    public Vector3 enemyPosition = Vector3.zero;
    public Vector3 pacmanPosition = Vector3.zero;
    public Vector3 ghostVector = Vector3.zero;

    private Vector3 up = Vector3.zero,
                    upMove = new Vector3(10, 0, 0),
                    right = new Vector3(0, 90, 0),
                    rightMove = new Vector3(0,0,10),
                    down = new Vector3(0, 180, 0),
                    downMove = new Vector3(-10,0, 0),
                    left = new Vector3(0, 270, 0),
                    leftMove = new Vector3(0, 0,-10),
                    currentDirection = Vector3.zero;

    private Vector3 initialPosition = Vector3.zero;
    public int number = 1;
    public int directionValue = 1;
    private Animator animator = null;
    // Start is called before the first frame update
    void Reset()
    {

        transform.position = initialPosition;

        animator.SetBool("isDead", false);
        animator.SetBool("isMoving", false);
        directionValue = 1;
        currentDirection = down;
        
    }

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        ghostSpeed = moveSpeed * Time.deltaTime ;
        initialPosition = transform.position;
        enemyPosition = transform.position;
        animator = GetComponent<Animator>();
        The_rb = GetComponent<Rigidbody>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        var isMoving = true;
        number = Random.Range(1, 1000000) % 2;
       // ghostSpeed = moveSpeed * Time.deltaTime ;

        if (isMoving == true)
        {
      
        }
        transform.localEulerAngles = currentDirection;

        if (isMoving)
            The_rb.velocity = ghostVector;
           // transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);

    }
    void OnTriggerEnter(Collider other)
    {
        ghostSpeed = moveSpeed * Time.deltaTime ;
       // number = Random.Range(1, 2);
        if (other.CompareTag("Wall"))
        {

            if(directionValue == 0 || directionValue == 1)
            {
                if(number == 1)
                {
                    directionValue = 2;
                    currentDirection = left;
                    ghostVector = new Vector3(ghostSpeed, 0f,0f);
                }
                else
                {
                    directionValue = 3;
                    currentDirection = right;
                    ghostVector = new Vector3(-ghostSpeed, 0f,0f);
                }
            }
            else
            {
                if(number == 1)
                {
                    directionValue = 1;
                    currentDirection = down;
                    ghostVector = new Vector3(0, 0f,-ghostSpeed);
                }
                else
                {
                    directionValue = 0;
                    currentDirection = up;
                    ghostVector = new Vector3(0f, 0f,ghostSpeed);
                }
            }
          

        }
            
        

    }
}
