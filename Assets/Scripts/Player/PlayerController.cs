using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private ChargeRifle chargeRifleScript;
    [SerializeField] private GameObject rayGunCollider;
    [SerializeField] private GameObject chargeRifle;
    [SerializeField] private GameObject rayGun;
    private Rigidbody2D body;

    [Header ("Player Configurations")]
    [SerializeField] private float speed;
    [HideInInspector] public float slownessEffect = 1f;
    private Vector2 moveDirection;
    private bool stopMoving = false;

    [Header ("Weapon Configurations")]
    [SerializeField] private float chargeRifleTime;
    private float chargeRifleCountdown;
    private bool usingRayGun;
    
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        MovementInputs();

        WeaponInputs();

        ChargeRifleInputs();  

        RayGunInputs(); 
    }

    private void FixedUpdate() {
        Move();
    }

    private void MovementInputs() {
        float XInput = Input.GetAxisRaw("Horizontal");
        float YInput = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(XInput, YInput).normalized;
    }

    private void WeaponInputs() {

        if(Input.GetKeyDown(KeyCode.Q)) {
            usingRayGun = !usingRayGun;
        }

        if(usingRayGun == true) {
            rayGun.SetActive(true);
            chargeRifle.SetActive(false);
        }
        else {
            rayGun.SetActive(false);
            chargeRifle.SetActive(true);
        }
    }

    private void ChargeRifleInputs() { 
        if(usingRayGun) {
            return;
        }
        else {
            if(Input.GetMouseButtonDown(0)) {
                chargeRifleCountdown = chargeRifleTime;
            }
            if(Input.GetMouseButton(0)) {
                chargeRifleCountdown -= Time.deltaTime;
            }
            if(chargeRifleCountdown <= 0 && Input.GetMouseButtonUp(0)) {
                chargeRifleScript.Fire();
            }
        }
    }

    private void RayGunInputs() {
        if(!usingRayGun) {
            return;
        }
        else {
            if(Input.GetMouseButton(0)) {
                rayGunCollider.SetActive(true);
            }
            else {
                rayGunCollider.SetActive(false);
            }
        }
    }

    private void Move() {
        if (!stopMoving)
            body.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed * slownessEffect;
    }

    private void StopMoving() {
        GetComponent<CircleCollider2D>().isTrigger = enabled;
        body.velocity = Vector2.zero;
        stopMoving = true;
    }

    public void StopSlowness() {
        slownessEffect = 1f;
    }

}