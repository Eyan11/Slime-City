using UnityEngine;

public class RangedAlienMotor : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private GameObject alienMucus;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject firepointRotationObject;
    private RangedAlienFirepointRotation firepointRotationScript;
    private Transform target;
    private Rigidbody2D body;
    private Animator anim;

    [Header ("Alien Configurations")]
    [SerializeField] private float speed;
    [SerializeField] private float approachDistance;
    private Vector2 movement;
    private Vector2 distance;
    private bool stopMoving = false;

    [Header ("Projectile Configurations")]
    [SerializeField] private float damage;
    [SerializeField] private float fireForce;
    [SerializeField] private float shootTime;
    [HideInInspector] public float slownessEffect = 1f;
    private float shootCountdown;

    private void Awake() {
        target = GameObject.FindWithTag("Player").transform;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        firepointRotationScript = firepointRotationObject.GetComponent<RangedAlienFirepointRotation>();

        shootCountdown = shootTime;
    }

    private void Update() {
        MovementCalculations();
        Attack();
    }

    private void FixedUpdate() {
        if(!stopMoving)
            Movement(movement);
    }

    private void MovementCalculations() {
        distance = target.position - transform.position;

        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg - 90;
        firepointRotationScript.RotateFirePoint(angle);

        anim.SetFloat("Direction", angle);

        Vector2 direction = distance;
        direction.Normalize();
        movement = direction;
    }

    private void Movement(Vector2 direction) {
        
        if(Mathf.Abs(distance.x) + Mathf.Abs(distance.y) > approachDistance) {
            body.MovePosition((Vector2)transform.position + (direction * speed * slownessEffect * Time.deltaTime));
        }
        else {
            body.MovePosition((Vector2)transform.position + (-direction * speed * slownessEffect * Time.deltaTime));
        }
    }

    private void StopMoving() {
        stopMoving = true;
    }

    private void Attack() {
        shootCountdown -= Time.deltaTime;

        if(shootCountdown <= 0) {
            GameObject projectile = Instantiate(alienMucus, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            shootCountdown = shootTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
