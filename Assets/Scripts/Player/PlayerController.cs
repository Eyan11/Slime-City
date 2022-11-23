using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private ChargeRifle chargeRifleScript;
    [SerializeField] private GameObject rayGunCollider;
    [SerializeField] private GameObject chargeRifle;
    [SerializeField] private GameObject rayGun;
    [SerializeField] private ShopInteraction shopScript;
    [SerializeField] private Slider chargeSlider;
    [SerializeField] private Image fill;
    [SerializeField] private GameObject sliderObject;
    [SerializeField] private InventorySlot inventoryScript;
    private Rigidbody2D body;
    private float rayGunBeamAudioDelay = 0.7f;
    private float rayGunBeamAudioTimer = 0f;
    private bool playingRayGunBeamAudio = false;

    [Header ("Player Configurations")]
    [SerializeField] private float speed;
    [HideInInspector] public float slownessEffect = 1f;
    private Vector2 moveDirection;
    private bool stopMoving = false;

    [Header ("Weapon Configurations")]
    [SerializeField] private float chargeRifleTime;
    private float chargeRifleCountdown;
    private bool usingRayGun = true;
    private bool usingChargeRifle;
    
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        chargeSlider.maxValue = chargeRifleTime;
        inventoryScript.HighlightSelectedSlot(1);
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

        if(Input.GetKeyDown("1")) {
            usingRayGun = true;
            usingChargeRifle = false;
            sliderObject.SetActive(false);
            inventoryScript.HighlightSelectedSlot(1);
            FindObjectOfType<AudioManager>().Play("SelectRayGun");

            if (Input.GetMouseButton(0))
                FindObjectOfType<AudioManager>().Play("RayGunStart");
        }

        if(usingRayGun == false)
            FindObjectOfType<AudioManager>().Pause("RayGunBeam");

        if(Input.GetKeyDown("2") && shopScript.hasChargeRifle()) {
            usingChargeRifle = true;
            usingRayGun = false;
            sliderObject.SetActive(true);
            inventoryScript.HighlightSelectedSlot(2);
            FindObjectOfType<AudioManager>().Play("SelectChargeRifle"); 
        }

        if(Input.GetKeyDown("3") && shopScript.hasTurtle()) {
            usingChargeRifle = false;
            usingRayGun = false;
            sliderObject.SetActive(false);
            inventoryScript.HighlightSelectedSlot(3);
            FindObjectOfType<AudioManager>().Play("SelectTurtle"); 
        }

        if(Input.GetKeyDown("4") && shopScript.hasDog()) {
            usingChargeRifle = false;
            usingRayGun = false;  
            sliderObject.SetActive(false);      
            inventoryScript.HighlightSelectedSlot(4);    
            FindObjectOfType<AudioManager>().Play("SelectDog"); 
        }

        if(usingRayGun) {
            rayGun.SetActive(true);
            chargeRifle.SetActive(false);
        }
        else if (usingChargeRifle) {
            rayGun.SetActive(false);
            chargeRifle.SetActive(true);
        }
        else {
            rayGun.SetActive(false);
            chargeRifle.SetActive(false);
        }
    }

    private void ChargeRifleInputs() { 
        if(!usingChargeRifle) {
            return;
        }
        else {
            if(Input.GetMouseButtonDown(0)) {
                chargeRifleCountdown = 0;
            }
            if(Input.GetMouseButton(0)) {
                chargeRifleCountdown += Time.deltaTime;
            }
            if(chargeRifleCountdown >= chargeRifleTime && Input.GetMouseButtonUp(0)) {
                chargeRifleScript.Fire();
                FindObjectOfType<AudioManager>().Play("ChargeRifle");
            }
        }
        
        chargeSlider.value = chargeRifleCountdown;

        if(chargeRifleCountdown > chargeRifleTime)
            fill.color = Color.green;
        else
            fill.color = Color.white;
    }

    private void RayGunInputs() {
        if(!usingRayGun) {
            return;
        }
        if (Input.GetMouseButtonDown(0)) {
            FindObjectOfType<AudioManager>().Play("RayGunStart");
        }
        else if (Input.GetMouseButton(0)) {
            rayGunCollider.SetActive(true);

            if (playingRayGunBeamAudio == false) {  
                rayGunBeamAudioTimer += Time.deltaTime;
                if(rayGunBeamAudioTimer >= rayGunBeamAudioDelay) {
                    FindObjectOfType<AudioManager>().Play("RayGunBeam"); 
                    playingRayGunBeamAudio = true;
                }            
            }
        }
        else if (Input.GetMouseButtonUp(0)) {
            rayGunCollider.SetActive(false);
            FindObjectOfType<AudioManager>().Pause("RayGunStart");
            FindObjectOfType<AudioManager>().Pause("RayGunBeam");
            FindObjectOfType<AudioManager>().Play("RayGunEnd");
            rayGunBeamAudioTimer = 0f;
            playingRayGunBeamAudio = false;
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