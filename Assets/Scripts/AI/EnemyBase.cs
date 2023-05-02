using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : Attributes
{

    #region Health Variables

    [Header("Health Display")] public Gradient healthColour;
    public Canvas myHealthCanvas;
    private Transform _cam;

    #endregion

    #region AI Variables

    [Header("AI")] public Transform player;

    public enum AIStates
    {
        Patrol,
        Seek,
        Attack,
        Die
    }

    public AIStates state;
    [Header("AI Movement")] public Transform wayPointParent;
    public Transform[] waypoints;
    public int curPoint;
    public float distanceToPoint, changePoint;
    public float runSpeed, walkSpeed;
    public Animator anim;
    public NavMeshAgent agent;
    public float stopFromPlayer, turnSpeed;
    [Header("AI Level")] public int difficulty;
    public int maxDifficulty;
    public Material[] enemyMats;
    public Renderer rend;
    [Header("AI Attack")] public float attackSpeed;
    public float attackRange, sightRange, baseDamage;

    #endregion

    #region Health Override

    public override void SetHealth()
    {
        base.SetHealth();
        attributes[0].displayImage.color = healthColour.Evaluate(attributes[0].displayImage.fillAmount);
        myHealthCanvas.transform.LookAt(myHealthCanvas.transform.position + _cam.forward);
    }


    #endregion

    #region AI Behaviours

    public virtual void Patrol()
    {
        //DO not continue if no waypoints, dead, player in range
        if (waypoints.Length <= 0 || isDead || Vector3.Distance(player.position, transform.position) <= sightRange) 
        {
            //return throws us out of the behaviour
            return;
        }
        //set state
        state = AIStates.Patrol;
        //set animation
        anim.SetBool("Walk", true);
        
        //Set Speed
        agent.speed = walkSpeed;
        //Set stopping distance
        agent.stoppingDistance = 0;
        // set agent to target
        agent.destination = waypoints[curPoint].position;
        // check distance to waypoint
        distanceToPoint = Vector3.Distance(transform.position, waypoints[curPoint].position);
        //change waypoint if in range of current point
        if (distanceToPoint <= changePoint)
        {
            //if so go to next waypoint
            if (curPoint < waypoints.Length-1)
            {
                curPoint++;
            } // if at end of patrol go to start
            else
            {
                curPoint = 1;
            }
        }
    }

    public virtual void Seek()
    {
        // Temp var distance
        float distance = Vector3.Distance(player.position, transform.position);
        // if player is out of our sight range or inside our attack range
        if (distance > sightRange || distance < attackRange || isDead || player.GetComponent<PlayerHandler>().isDead)
        {
            //stop seeking
            return;
        }
        //Set AI state
        state = AIStates.Seek;
        //Set animation
        anim.SetBool("Run", true);
        // Set Stopping Distance
        agent.stoppingDistance = stopFromPlayer;
        // Change speed
        agent.speed = runSpeed;
        // Target is player
        agent.destination = player.position;
    }

    public virtual void Attack()
    {
        distanceToPoint = Vector3.Distance(player.position, transform.position);
        if (distanceToPoint > attackRange || isDead || player.GetComponent<PlayerHandler>().isDead)
        {
            return;
        }

        state = AIStates.Attack;
        anim.SetBool("Attack", true);
        agent.stoppingDistance = stopFromPlayer;
        agent.speed = 0;
        
    }

    public virtual void Die()
    {
        //if we are alive
        if (attributes[0].currentValue > 0||isDead)
        {
            //dont run this
            return;
        }
        //Set AI state
        state = AIStates.Die;
        //Set animation
        anim.SetTrigger("Die");
        //stop moving
        agent.destination = transform.position;
        agent.speed = 0;
        agent.enabled = false;
        //Drop Loot/Quest Item
        //is dead
        isDead = true;
    }

#endregion

    #region Difficulty
    public void Difficulty()
    {
        difficulty = Random.Range(1, maxDifficulty + 1);
        rend.material = enemyMats[difficulty - 1];
    }

    #endregion

    #region Unity Event Methods/Functions
    public virtual void Start()
    {
        _cam = Camera.main.transform;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent.speed = walkSpeed;
        waypoints = wayPointParent.GetComponentsInChildren<Transform>();
        curPoint = 1;
        Patrol();
    }

    public override void Update()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);
        Patrol();
        Seek();
        Attack();
        Die();

        base.Update();
    }
    #endregion
}
