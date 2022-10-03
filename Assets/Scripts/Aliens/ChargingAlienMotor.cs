using UnityEngine;

public class ChargingAlienMotor : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Patrol patrol;
    [SerializeField] private Charge charge;
    private Transform target;
    private Animator anim;

    [Header ("Alien Configurations")]
    [SerializeField] private float damage;
    private Vector2 distance;

    [Header ("Charge Configurations")]
    [SerializeField] private float chargeRange;
    [SerializeField] private float startStunTime;
    private float stunTimer = 0;
    private bool isCharging = false;

    private void Awake() {
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    private void Update() {
        distance = target.position - transform.position;

        stunTimer -= Time.deltaTime;

        if(stunTimer <= 0) {
            anim.SetBool("Unlocking", false);

            if(Mathf.Abs(distance.x) + Mathf.Abs(distance.y) < chargeRange) {
                isCharging = true;
            }

            if(isCharging) {
                patrol.enabled = false;
                charge.enabled = true;
            }
            else {
                patrol.enabled = true;
                charge.enabled = false;

                anim.SetBool("Locking", false);
                anim.SetBool("Unlocking", false);
                anim.SetBool("Charging", false);
            }

        }
    }
    
    public void EndofCharge() {
        stunTimer = startStunTime;
        
        isCharging = false;
        charge.enabled = false;
        patrol.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
