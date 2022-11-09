using UnityEngine;

public class TurtleController : MonoBehaviour
{
    private Vector2 mousePosition;
    private Vector2 direction;
    private bool guardingPlayer = true;
    private bool isSelectingTurtle = false;

    [Header ("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float minFollowDistance;

    [Header ("References")]
    private Transform player;
    private Rigidbody2D body;
    private Camera sceneCamera;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        sceneCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update() {
        //PulseAttack();

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
}
