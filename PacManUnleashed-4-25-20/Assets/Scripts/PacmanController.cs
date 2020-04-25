using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;

public class PacmanController : MonoBehaviour
{
   private static System.Timers.Timer aTimer;
  // public float MovementSpeed = 0f;
    public float moveSpeed;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    public CharacterController controller;
    private bool isDead = false;
    private float   up = 0f,
                    right = 90f,
                    down = 180f,
                    left = 270f,
                    currentDirection = 0f;

    private Vector3 initialPosition = Vector3.zero;

    private Animator animator = null;

     public GameObject Life1, Life2, Life3;
    public static int health;

    public void Reset()
    {
        transform.position = initialPosition;

        animator.SetBool("isDead", false);
        animator.SetBool("isMoving", false);
               //Do the life stuff here
//        if(health > 3)
//            health = 3; // max lives = 3
//        switch(health) {
//            case 3:
//                Life1.gameObject.SetActive(true);
//                Life2.gameObject.SetActive(true);
//                Life3.gameObject.SetActive(true);
//                break;
//            case 2:
//                Life1.gameObject.SetActive(true);
//                Life2.gameObject.SetActive(true);
//                Life3.gameObject.SetActive(false);
//                break;
//            case 1:
//                Life1.gameObject.SetActive(true);
//                Life2.gameObject.SetActive(false);
//                Life3.gameObject.SetActive(false);
//                break;
//            case 0:
//                Life1.gameObject.SetActive(false);
//                Life2.gameObject.SetActive(false);
//                Life3.gameObject.SetActive(false);
//                break;
//        }
//        print("health " + health);
        currentDirection = down;

    }


    // Start is called before the first frame update
    void Start()
    {
        SetTimer();
        QualitySettings.vSyncCount = 0;

        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
      //  animator.SetBool("isMoving", true);

       health = 3;
        Life1.gameObject.SetActive(true);
        Life2.gameObject.SetActive(true);
        Life3.gameObject.SetActive(true);
        print("health " + health);
        
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        var isMoving = true;
        isDead = animator.GetBool("isDead");


        //Used to change ghosts to scared mode
        if (Input.GetKey(KeyCode.Space)){
          GameObject[] ghosts =GameObject.FindGameObjectsWithTag("Enemy");
          
          foreach (GameObject go in ghosts)
          {
            go.GetComponent<GhostFollow> ().startScaredGhost ();
          }
           
        }

        
       


        if (isDead) isMoving = false;
        else if (Input.GetKey(KeyCode.UpArrow)) currentDirection = up;
        else if (Input.GetKey(KeyCode.RightArrow)) currentDirection = right;
        else if (Input.GetKey(KeyCode.DownArrow)) currentDirection = down;
        else if (Input.GetKey(KeyCode.LeftArrow)) currentDirection = left;
        else isMoving = false;

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, currentDirection, transform.localEulerAngles.z);
       // transform.Rotate(0,90,0,Space.Self);
        animator.SetBool("isMoving", isMoving);

        if (isMoving){
          //  transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
            moveDirection = new Vector3(Input.GetAxis("Horizontal")*moveSpeed, 0f, Input.GetAxis("Vertical")*moveSpeed);
            Debug.Log(moveDirection);
            controller.Move(moveDirection * Time.deltaTime);
        }

              if(health > 3)
            health = 3; // max lives = 3
        switch(health) {
            case 3:
                Life1.gameObject.SetActive(true);
                Life2.gameObject.SetActive(true);
                Life3.gameObject.SetActive(true);
                break;
            case 2:
                Life1.gameObject.SetActive(true);
                Life2.gameObject.SetActive(true);
                Life3.gameObject.SetActive(false);
                break;
            case 1:
                Life1.gameObject.SetActive(true);
                Life2.gameObject.SetActive(false);
                Life3.gameObject.SetActive(false);
                break;
            case 0:
                Life1.gameObject.SetActive(false);
                Life2.gameObject.SetActive(false);
                Life3.gameObject.SetActive(false);
                break;
        }
        print("health " + health);
    }

    void OnTriggerEnter(Collider other)
    {
        bool alive;
        if(!isDead){
         if (other.CompareTag("Enemy")){
            animator.SetBool("isDead", true);
            health--;
            aTimer.Stop();
            aTimer.Dispose();
            
          }
       // else if (other.CompareTag("Wall"))
            //while(other.CompareTag("Wall"))
       //     animator.SetBool("isMoving", false);

       }
    }

    private static void SetTimer()
   {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(2000);
        // Hook up the Elapsed event for the timer. 
        
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }
}
