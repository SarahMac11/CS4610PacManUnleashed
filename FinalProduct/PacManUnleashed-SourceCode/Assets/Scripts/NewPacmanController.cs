using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPacmanController : MonoBehaviour
{
    public float MovementSpeed = 0f;

    public Rigidbody rb;

    private Vector3 up = Vector3.zero,
                    right = new Vector3(0, 90, 0),
                    down = new Vector3(0, 180, 0),
                    left = new Vector3(0, 270, 0),
                    currentDirection = Vector3.zero;

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
        //  animator.SetBool("isMoving", true);
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        var isMoving = true;
        var isDead = animator.GetBool("isDead");


        if (isDead) isMoving = false;
        else if (Input.GetKey(KeyCode.UpArrow)) currentDirection = up;
        else if (Input.GetKey(KeyCode.RightArrow)) currentDirection = right;
        else if (Input.GetKey(KeyCode.DownArrow)) currentDirection = down;
        else if (Input.GetKey(KeyCode.LeftArrow)) currentDirection = left;
        else isMoving = false;

        transform.localEulerAngles = currentDirection;
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
          //  rb.AddForce(0, 0, MovementSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);


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
