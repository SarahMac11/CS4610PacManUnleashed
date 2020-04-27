using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;
using UnityEngine.SceneManagement;

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
    GameObject[] pacdots;

    private Animator animator = null;
    private bool isEmpty = false;
    public static int pacdotCounter;

    public GameObject Life1, Life2, Life3;
    public static int health;
    public Transform Teleporter1;
    public Transform Teleporter2;
    
    public AudioClip death;
    public AudioClip chomp;
    public AudioSource audioSrc;
//    public float volume = PlayerPrefs.GetFloat("SliderVolumeLevel", death.volume);
        
    public float volume = 0.7f;
    
    public void Reset()
    {
        transform.position = initialPosition;
        isEmpty = false;
        animator.SetBool("isDead", false);
        animator.SetBool("isMoving", false);
               //Do the life stuff here
        currentDirection = down;

    }


    // Start is called before the first frame update
    void Start()
    {
        // Get audio
        audioSrc = GetComponent<AudioSource> ();
//        
//        // get slider volume level if set
//        audio.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", death.volume);
        
        //SetTimer();
        QualitySettings.vSyncCount = 0;

        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        //  animator.SetBool("isMoving", true);
        pacdotCounter = 286;
       health = 3;
        Life1.gameObject.SetActive(true);
        Life2.gameObject.SetActive(true);
        Life3.gameObject.SetActive(true);
        //  print("health " + health);
        GameObject[] pacdots = GameObject.FindGameObjectsWithTag("Pacdot");
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        var isMoving = true;
        isDead = animator.GetBool("isDead");

     

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
          //  Debug.Log(moveDirection);
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
                // end game
                isMoving = false;
                // show game over page
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
       // print("health " + health);
    }

    void OnTriggerEnter(Collider other)
    {
        
        //  bool alive;
        SetTimer();
      
      if(!isDead && GhostFollow.ghostMode==1){
         if (other.CompareTag("Enemy")){
            animator.SetBool("isDead", true);
            health--;
            aTimer.Stop();
            aTimer.Dispose();
            // play death audio
            audioSrc.PlayOneShot(death, volume);
          }
       // else if (other.CompareTag("Wall"))
            //while(other.CompareTag("Wall"))
       //     animator.SetBool("isMoving", false);

        }
       
       if (other.CompareTag("Teleporter1")){
         if (Input.GetKey(KeyCode.LeftArrow)){
         controller.enabled=false;
         transform.position = Teleporter2.position;
         controller.enabled=true;
         }
       }
        if (other.CompareTag("Teleporter2")){
          if (Input.GetKey(KeyCode.RightArrow)){
         controller.enabled=false;
         transform.position = Teleporter1.position;
         controller.enabled=true;
          }
       }
       
       if(other.CompareTag("Pacdot")) {
            audioSrc.PlayOneShot(chomp, volume);
            pacdotCounter -= 1;
            //Debug.Log(pacdotCounter);
            if(pacdotCounter == 0)
            {
                //pacdotCounter = 286;
                //isEmpty = true;
                //Debug.Log(isEmpty);
                controller.enabled = false;
                Reset();
                controller.enabled = true;
                GameObject[] pacdots = GameObject.FindGameObjectsWithTag("Pacdot");
                for(int i = 0; i < 286; i++)
                {
                    pacdots[i].SetActive(true);
                }
                //Pacdot.gameObject.SetActive(true);
            }
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
