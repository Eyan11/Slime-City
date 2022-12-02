using UnityEngine;

public class TurtleController : MonoBehaviour
{
    private Vector2 mousePosition;
    private Vector2 direction;
    private bool guardingPlayer = true;
    private bool isSelectingTurtle = false;
    private float shootTimer;
    private bool inShell = false;

    [Header ("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float minFollowDistance;
    [SerializeField] private float ShootInterval;
    [SerializeField] private float bulletSpeed;

    [Header ("References")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Animator anim;
    private Transform player;
    private Rigidbody2D body;
    private Camera sceneCamera;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        sceneCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update() {
        Shoot();

        TurtleAnimations();

        if(Input.GetKeyDown("3")) {
            isSelectingTurtle = true;
        }
        if(Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("4")) {
            isSelectingTurtle = false;
        }

        if(isSelectingTurtle) {
            SelectingTurtle();
        }
        if (guardingPlayer) {
            GuardPlayerCalculations();
        }
    }

    private void FixedUpdate() {
        MoveTurtle();

        RotateTurtle();
    }

    private void SelectingTurtle() {

        if (Input.GetMouseButtonDown(0)) {
            guardingPlayer = false;
            SitPositionCalculations();
        }
        else if (Input.GetMouseButtonDown(1)) {
            guardingPlayer = true;
        }
    }

    private void GuardPlayerCalculations() {
        // When turtle is far from player
        if (Vector2.Distance(transform.position, player.transform.position) > minFollowDistance) {
            direction = -(transform.position - player.transform.position);
        }

        // When turtle is close to player
        else {
            direction = Vector2.zero;
        }
    }

    private void SitPositionCalculations() {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition;
    }

    private void MoveTurtle() {
        if(guardingPlayer) {
            body.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime * 4.5f);
        }

    }

    private void Shoot() {
        shootTimer += Time.deltaTime;

        if(shootTimer >= ShootInterval) {
            GameObject projectileUp = Instantiate(bullet, transform.position, Quaternion.identity);
            projectileUp.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);

            GameObject projectileDown = Instantiate(bullet, transform.position, Quaternion.identity);
            projectileDown.GetComponent<Rigidbody2D>().AddForce(-transform.up * bulletSpeed, ForceMode2D.Impulse);

            GameObject projectileLeft = Instantiate(bullet, transform.position, Quaternion.identity);
            projectileLeft.GetComponent<Rigidbody2D>().AddForce(-transform.right * bulletSpeed, ForceMode2D.Impulse);

            GameObject projectileRight = Instantiate(bullet, transform.position, Quaternion.identity);
            projectileRight.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);

            FindObjectOfType<AudioManager>().Play("TurtleWeapon");
            
            shootTimer = 0;
        }
    }

    private void RotateTurtle() {
        if(inShell) {
            return;
        }

        //Look at Player
        float rotateDirection = Mathf.Atan2(-(transform.position.y - player.transform.position.y), -(transform.position.x - player.transform.position.x)) * Mathf.Rad2Deg + 90f;;
        body.rotation = rotateDirection;
    }

    private void TurtleAnimations() {
        //If position is equal to desired destination, then turtle is no longer moving
        if(direction == new Vector2(transform.position.x, transform.position.y) && !inShell) {
            anim.SetTrigger("IntoShell");
            inShell = true;
        }
        else if(direction != new Vector2(transform.position.x, transform.position.y) && inShell) {
            anim.SetTrigger("ExitShell");
            inShell = false;
        }

        anim.SetBool("isIdle", direction == Vector2.zero);

    }
}
