using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRobotEnemy : MonoBehaviour
{
    //Finite state machine
    public enum NPCstate
    {
        Patrolling,
        Idle,
        Chasing,
        Attacking,

    };

    //public floats
    public float closeEnoughToAttack = 2f; //close enough to attack
    public float closeEnoughToChase = 5f;
    public float farEnough = 4f;
    public float speed = 1;
    private float waitTime;
    public float startWaitTime;

    int currentWaypointIndex = 0;

    //public nps states
    public NPCstate currenstate = NPCstate.Patrolling;

    //public bools
    public bool closeToPlayer;

    //Game Objects
    public GameObject player;
    GameObject[] waypoints;
    public Animator animator;
    private bool isFacingRight;

    //shooting logic
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] float fireRate;
    private float fireCounter;
    public float bulletSpeed;

    //change state method
    void ChangeState(NPCstate newState)
    {
        currenstate = newState;
    }

    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        if(player != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            StartCoroutine(LookForPlayer());
        }
        
        waitTime = startWaitTime;
        isFacingRight = false;
    }

    IEnumerator LookForPlayer()
    {
        yield return new WaitForSeconds(6);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void HandleFSM()
    {
        switch (currenstate)
        {
            case NPCstate.Patrolling:
                HandlePatrollingState();
                break;
            case NPCstate.Idle:
                HandleIdleState();
                break;
            case NPCstate.Chasing:
                HandleChasingState();
                break;
            case NPCstate.Attacking:
                HandleAttackingState();
                break;
            default:
                break;
        }

    }


    void Update()
    {
        HandleFSM();
    }

    private void HandlePatrollingState()
    {
        Vector3 target = waypoints[currentWaypointIndex].transform.position;
        Debug.Log("NPC in patrolling state");

        if (Vector3.Distance(this.transform.position, player.transform.position) < closeEnoughToChase)
        {
            ChangeState(NPCstate.Chasing);
        }
        if (Vector3.Distance(this.transform.position, target) < .1)
        {
            ChangeState(NPCstate.Idle);
        }

        FollowingPatrollingPath();
    }
    private void FollowingPatrollingPath()
    {
        Vector3 target = waypoints[currentWaypointIndex].transform.position;

        //If in waypoint, calculate next waypoint index
        if (Vector3.Distance(this.transform.position, target) < .1)
        {
            currentWaypointIndex = CalculateNextWaypointIndex();
            target = waypoints[currentWaypointIndex].transform.position;
            Flip();

            Vector3 movement = MyMoveTowards(this.transform.position, target, -1 *speed * Time.deltaTime);
            this.transform.position = movement;
        }
        else
        {
            Vector3 movement = MyMoveTowards(this.transform.position, target, speed * Time.deltaTime);
            this.transform.position = movement;
        }

        
    }

    void Flip()
    {
        // Flip player
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }

    //Custom move towards
    Vector3 MyMoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta)
    {
        Vector3 currentToTarget = target - current;


        Vector3 movement = current + currentToTarget.normalized * maxDistanceDelta;
        return movement;
    }
    private int CalculateNextWaypointIndex()
    {
        //Follow in order
        return currentWaypointIndex = ((currentWaypointIndex + 1) % waypoints.Length);
    }

    private void HandleChasingState()
    {
        Debug.Log("NPC in chasing state");

        if (Vector3.Distance(this.transform.position, player.transform.position) < this.closeEnoughToAttack)
        {
            ChangeState(NPCstate.Attacking);
        }
        else if (Vector3.Distance(this.transform.position, player.transform.position) > farEnough)
        {
            ChangeState(NPCstate.Patrolling);
        }
        else
        {
            //this.transform.position = MyMoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if (player.transform.position.x > this.gameObject.transform.position.x && isFacingRight == false)
            {
                Flip();
                this.transform.position = MyMoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                this.transform.position = MyMoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            }

        }
    }

    private void HandleAttackingState()
    {
        Debug.Log("NPC in attack state");
        float d = Vector3.Distance(this.transform.position, player.transform.position);
        
        if (d <= closeEnoughToAttack)
        {
            //fireCounter -= Time.deltaTime;
            //if (fireCounter <= 0)
            //{
            //    soundsManager.PlaySound("enemyShoot");
            //    fireCounter = fireRate;
            //    Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            //}

            if (player.transform.position.x > this.gameObject.transform.position.x && isFacingRight == false)
            {
                Flip();
                animator.SetBool("isPlayerInRange", true);
                speed = 0;
                fireCounter -= Time.deltaTime;
                if (fireCounter <= 0)
                {
                    soundsManager.PlaySound("enemyShoot");
                    fireCounter = fireRate;
                    Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                }
            }
            else
            {
                animator.SetBool("isPlayerInRange", true);
                speed = 0;
                fireCounter -= Time.deltaTime;
                if (fireCounter <= 0)
                {
                    soundsManager.PlaySound("enemyShoot");
                    fireCounter = fireRate;
                    Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
                }
            }

        }
        else
        {
            speed = 3;
            fireCounter -= Time.deltaTime;
            animator.SetBool("isPlayerInRange", false);
            ChangeState(NPCstate.Patrolling);
        }

    }

    private void HandleIdleState()
    {
        Debug.Log("NPC in idle state");
        if (waitTime <= 0)
        {
            ChangeState(NPCstate.Patrolling);
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }


    }


}
