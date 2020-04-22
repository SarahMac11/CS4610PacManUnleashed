using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    public float MovementSpeed = 0f;

    public Vector3 enemyPosition = Vector3.zero;
    public Vector3 pacmanPosition = Vector3.zero;

    private Vector3 up = Vector3.zero,
                    right = new Vector3(0, 90, 0),
                    down = new Vector3(0, 180, 0),
                    left = new Vector3(0, 270, 0),
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

        initialPosition = transform.position;
        enemyPosition = transform.position;
        animator = GetComponent<Animator>();

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        var isMoving = true;
        number = Random.Range(1, 1000000) % 2;
        Debug.Log(number);
        Debug.Log(currentDirection);
        //pacmanPosition = GameObject.FindWithTag("Pacman").transform.position;
        //enemyPosition = transform.position;

        if (isMoving == true)
        {
         /*   if ((enemyPosition.z - pacmanPosition.z) > (enemyPosition.x - pacmanPosition.x) || (enemyPosition.z + pacmanPosition.z) > (enemyPosition.x + pacmanPosition.x))
            {
                if ((enemyPosition.z - pacmanPosition.z) > (enemyPosition.x - pacmanPosition.x))
                {
                    currentDirection = down;
                }
                else
                {
                    currentDirection = left;
                }
            }
            else
            {
                if ((enemyPosition.x - pacmanPosition.x) > (enemyPosition.z - pacmanPosition.z))
                {
                    currentDirection = right;
                }
                else
                {
                    currentDirection = up;
                }

            }*/
        }
        transform.localEulerAngles = currentDirection;

        if (isMoving)
            transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);

    }
    void OnTriggerEnter(Collider other)
    {
       // number = Random.Range(1, 2);
        if (other.CompareTag("Wall"))
        {

            if(directionValue == 0 || directionValue == 1)
            {
                if(number == 1)
                {
                    directionValue = 2;
                    currentDirection = left;
                }
                else
                {
                    directionValue = 3;
                    currentDirection = right;
                }
            }
            else
            {
                if(number == 1)
                {
                    directionValue = 1;
                    currentDirection = down;
                }
                else
                {
                    directionValue = 0;
                    currentDirection = up;
                }
            }
            //if up/down -> left/right
            //if left/right ->up/down
           // while (other.CompareTag("Wall"))
            //{
            /*    switch (number)
                {
                    case 1:
                        currentDirection = up;
                        break;
                    case 2:
                        currentDirection = down;
                        break;
                    case 3:
                        currentDirection = right;
                        break;
                    case 4:
                        currentDirection = left;
                        break;
                }*/
           // }

        }
            
        

    }
}
