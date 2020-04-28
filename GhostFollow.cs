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
    public int scaredModeDuration = 10;
    public int startBlinking = 7;
    private float scaredModeTimer = 0;
    private float blinkTimer = 0;
    public int blink = 1;

    public static int ghostMode = 1;

    public Vector3 offset;
    public float distance;

    private Vector3 initialPosition = Vector3.zero;

    // eat ghost audio
    public AudioSource eatGhost;

    //Ghosts Modes for Animation
    public enum Mode
    {
        Scared,
        Normal
    }

    Mode currentMode = Mode.Normal;

    void Start()
    {
        // Get audio
        eatGhost = GetComponent<AudioSource>();
        // get slider volume level if set
        eatGhost.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", eatGhost.volume);

        player = GameObject.FindGameObjectWithTag("Pacman");
        enemy = GetComponent<NavMeshAgent>();
        spawn = GameObject.FindGameObjectWithTag("Spawn");

        initialPosition = transform.position;

        UpdateAnimatorController();
    }

    // Update is called once per frame
    void Update()
    {
        if (PacmanController.pacdotCounter == 0)
        {
            transform.position = spawn.transform.position;
        }

        float distance_between = Vector3.Distance(enemy.transform.position, player.transform.position);


        if (currentMode == Mode.Scared)
        {
            //slightly slow down ghosts and run away from pacman
            GetComponent<NavMeshAgent>().speed = 4;
            enemy.destination = player.transform.position + (transform.position - player.transform.position) * 2;
            ghostMode = 0;
        }

        if (currentMode != Mode.Scared)
        {
            //Normal.Mode follow Pacman
            if (distance_between < distance)
            {
                enemy.destination = player.transform.position;
            }
            else
            {
                enemy.destination = player.transform.position + offset;
            }
            GetComponent<NavMeshAgent>().speed = 7;
            ghostMode = 1;

        }


        UpdateAnimatorController();


    }



    void UpdateAnimatorController()
    {
        if (currentMode == Mode.Scared)
        {
            if (blink == 1)
            {
                transform.GetComponent<Animator>().runtimeAnimatorController = scaredGhost;
            }

            scaredModeTimer += Time.deltaTime;

            if (scaredModeTimer >= startBlinking) //Blinking not working.....
            {

                if (blink == 1)
                {
                    blink = 0;
                    transform.GetComponent<Animator>().runtimeAnimatorController = blinkingGhost;
                }

                blinkTimer += Time.deltaTime;

            }


            if (scaredModeTimer >= scaredModeDuration)
            {
                scaredModeTimer = 0;
                changeMode(Mode.Normal);


            }
        }
        else
        {
            transform.GetComponent<Animator>().runtimeAnimatorController = normalGhost;
            blink = 1;
        }
    }


    //Change mode of Ghosts
    void changeMode(Mode a)
    {
        currentMode = a;
        UpdateAnimatorController();
    }


    public void startScaredGhost()
    {
        changeMode(Mode.Scared);

    }

    void OnTriggerEnter(Collider other)
    {
        // if collision with scared ghost
        if (ghostMode == 0)
        {
            if (other.CompareTag("Pacman"))
            {
                transform.position = spawn.transform.position;
                // increment score when run into ghost
                Score.score += 100;
                // increment health
                PacmanController.health++;
                // Play eat ghost audio
                eatGhost.Play();
            }
        }

    }






}
