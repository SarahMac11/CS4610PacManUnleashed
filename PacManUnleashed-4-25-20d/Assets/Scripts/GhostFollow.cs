using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostFollow : MonoBehaviour
{
    GameObject player;
    NavMeshAgent enemy;
    GameObject spawn;
    // Start is called before the first frame update


    //Runtime Animator Controller (can set in Unity )
    public RuntimeAnimatorController scaredGhost;
    public RuntimeAnimatorController normalGhost;
    public RuntimeAnimatorController blinkingGhost;

    //Timer Variables
    public int scaredModeDuration= 10;
    public int startBlinking=7;
    private float scaredModeTimer = 0;
    private float blinkTimer=0;
    public int blink=1;

    public static int ghostMode=1;

    private Vector3 initialPosition = Vector3.zero;



    //Ghosts Modes for Animation
    public enum Mode {
        Scared,
        Normal
    }

    Mode currentMode=Mode.Normal;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Pacman");
        enemy = GetComponent<NavMeshAgent>();
        spawn= GameObject.FindGameObjectWithTag("Spawn");

        initialPosition = transform.position;
        
        UpdateAnimatorController();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentMode== Mode.Scared)
        {
            //slightly slow down ghosts and run away from pacman
            GetComponent<NavMeshAgent>().speed = 4;
            enemy.destination=player.transform.position+(transform.position-player.transform.position)*2;
            ghostMode=0;
        }
        else
        {
            //Normal.Mode follow Pacman
            enemy.destination=player.transform.position;
            GetComponent<NavMeshAgent>().speed = 7;
            ghostMode=1;
        }
      



        UpdateAnimatorController();


    }



    void UpdateAnimatorController (){
        if (currentMode== Mode.Scared)
        {
            if(blink==1)
            {
             transform.GetComponent<Animator> ().runtimeAnimatorController= scaredGhost;
            }
   
            scaredModeTimer += Time.deltaTime;

            if(scaredModeTimer >= startBlinking) //Blinking not working.....
            {
                
                if(blink==1)
                {
                    blink=0;
                    transform.GetComponent<Animator> ().runtimeAnimatorController= blinkingGhost;
                }

                blinkTimer += Time.deltaTime;
                
            }


            if (scaredModeTimer >= scaredModeDuration)
            {
                scaredModeTimer=0;
                changeMode(Mode.Normal);

               
            }
        }
        else
        {
            transform.GetComponent<Animator> ().runtimeAnimatorController= normalGhost;
            blink=1;
        }
    }


//Change mode of Ghosts
    void changeMode (Mode a)
    {
        currentMode=a;
        UpdateAnimatorController ();
    }


    public void startScaredGhost ()
    {
        changeMode(Mode.Scared);

    }

    void OnTriggerEnter(Collider other)
    {
        


      if(ghostMode==0)
      {
       if(other.CompareTag("Pacman"))
       {
  
           transform.position = spawn.transform.position;
       }
      }
         
    }






}
