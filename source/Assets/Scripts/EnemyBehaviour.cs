using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform player;

    private Animator anim;

    public EnemyShootingController weapon;

    public float range = 15f;
    

    public float speed = 1f;
    public float moveRadius = 3f;

    public float idleTimeMin = 1.5f;
    public float idleTimeMax = 4f;

    private Vector3 moveTarget;
    private float stateTimer;

    private bool isMoving;

    void Start()
    {
        anim = GetComponent<Animator>();
        EnterIdle();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        HandleRotation();
        HandleMovementState();
        HandleShooting();

        anim.SetFloat("Speed", isMoving ? 1f : 0f);
    }

    void HandleRotation()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
    }

    void HandleMovementState()
    {
        stateTimer -= Time.deltaTime;

        if (isMoving)
        {
            Move();

            if (Vector3.Distance(transform.position, moveTarget) < 0.2f)
                EnterIdle();
        }
        else
        {
            if (stateTimer <= 0f)
                EnterMove();
        }
    }

    void Move()
    {
        Vector3 dir = (moveTarget - transform.position);
        dir.y = 0f;

        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    void EnterIdle()
    {
        isMoving = false;
        stateTimer = Random.Range(idleTimeMin, idleTimeMax);
    }

    void EnterMove()
    {
        isMoving = true;

        Vector2 random = Random.insideUnitCircle * moveRadius;

        moveTarget = new Vector3(
            transform.position.x + random.x,
            transform.position.y,
            transform.position.z + random.y
        );
    }

    void HandleShooting()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, dir);
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= range && angle < 60f)
        {
            weapon.TryShoot();
        }
    }
}