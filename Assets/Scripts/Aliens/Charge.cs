using UnityEngine;

public class Charge : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private ChargingAlienMotor chargingAlienMotor;
    private Transform target;
    private Rigidbody2D body;
    private Animator anim;

    [Header ("Charge Settings")]
    [SerializeField] private float startChargeTime;
    [SerializeField] private float chargeDuration;
    [SerializeField] private float chargeSpeed;
    private float speed = 1f;
    private Vector2 direction;
    private Vector2 distance;
    private float chargeTimer;
    private bool stopMoving = false;

    private void Awake() {
        target = GameObject.FindWithTag("Player").transform;
        body = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Start () {
        chargeTimer = startChargeTime;
    }

    private void FixedUpdate() {
        if(!stopMoving)
            body.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void StopMoving() {
        stopMoving = true;
    }

    private void Update() {
        distance = target.position - transform.position;
        chargeTimer -= Time.deltaTime;

        if(speed < chargeSpeed) {
            float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg - 90;
            anim.SetFloat("Direction", angle);
            anim.SetBool("Locking", true);
        }
    }

    private void ReadyToCharge() {
        direction = distance;
        direction.Normalize();

        anim.SetBool("Locking", false);
        anim.SetBool("Charging", true);

        speed = chargeSpeed;
        Invoke("StopCharging", chargeDuration);
        chargeTimer = startChargeTime;
    }

    private void StopCharging() {
        direction = Vector2.zero;
        speed = 1f;
        chargeTimer = startChargeTime;
        chargingAlienMotor.EndofCharge();

        anim.SetBool("Charging", false);
        anim.SetBool("Unlocking", true);
        anim.SetBool("Locking", false);
    }
}
