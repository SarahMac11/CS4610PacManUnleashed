using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanController : MonoBehaviour
{
 
  // public float MovementSpeed = 0f;
    public float moveSpeed;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    public CharacterController controller;

    private float   up = 0f,
                    right = 90f,
                    down = 180f,
                    left = 270f,
                    currentDirection = 0f;

    private Vector3 initialPosition = Vector3.zero;

    private Animator animator = null;

    public void Reset()
    {
        transform.position = initialPosition;

        animator.SetBool("isDead", false);
        animator.SetBool("isMoving", false);
        //Do the life stuff here
        currentDirection = down;

    }


    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;

        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
      //  animator.SetBool("isMoving", true);
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        var isMoving = true;
        var isDead = animator.GetBool("isDead");


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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            animator.SetBool("isDead", true);
       // else if (other.CompareTag("Wall"))
            //while(other.CompareTag("Wall"))
       //     animator.SetBool("isMoving", false);

    }
}
