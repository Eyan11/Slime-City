using UnityEngine;

public class FastAlienMotor : MonoBehaviour
{
    [Header ("Configurations")]
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private FastAlienAnimations fastAlienAnim;
    [HideInInspector] public float slownessEffect = 1f;
    private Vector2 movement;
    private Transform target;
    private Rigidbody2D body;
    private bool stopMoving = false;
    
    private void Awake() {
        target = GameObject.FindWithTag("Player").transform;
        body = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        MovementCalculations();
    }

    private void FixedUpdate() {
        Movement(movement);
    }

    private void MovementCalculations() {
        Vector2 direction = target.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        fastAlienAnim.GetDirectionAngle(angle);

        direction.Normalize();
        movement = direction;
    }

    private void Movement(Vector2 direction) {
        if (!stopMoving)
            body.MovePosition((Vector2)transform.position + (direction * speed * slownessEffect * Time.deltaTime));
    }

    private void StopMoving() {
        stopMoving = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
