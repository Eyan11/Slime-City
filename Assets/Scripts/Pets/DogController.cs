using UnityEngine;

public class DogController : MonoBehaviour
{
    private Vector2 mousePosition;
    private Vector2 direction;
    private bool guardingPlayer = true;
    private bool isSelectingDog = false;
    private GameObject[] multipleEnemies;
    private float firecooldown;
    private bool dontShoot = true;

    [Header ("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float minFollowDistance;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireIntervals;

    [Header ("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject rotatingFirepoint;
    private RotateDogGun rotateWeapon;
    private Transform player;
    private Rigidbody2D body;
    private Camera sceneCamera;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        sceneCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        rotateWeapon = rotatingFirepoint.GetComponent<RotateDogGun>();
        firecooldown = fireIntervals;
    }

    private void Update() {
        FindClosestEnemy();

        ShootEnemies();

        if(Input.GetKeyDown("4")) {
            isSelectingDog = true;
        }
        if(Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3")) {
            isSelectingDog = false;
        }

        if(isSelectingDog) {
            SelectingDog();
        }
        if (guardingPlayer) {
            GuardPlayerCalculations();
        }
    }

    private void FixedUpdate() {
        MoveDog();
    }

    private void SelectingDog() {

        if (Input.GetMouseButtonDown(0)) {
            guardingPlayer = false;
            SitPositionCalculations();
        }
        else if (Input.GetMouseButtonDown(1)) {
            guardingPlayer = true;
        }
    }

    private void GuardPlayerCalculations() {
        // When dog is far from player
        if (Vector2.Distance(transform.position, player.transform.position) > minFollowDistance) {
            direction = -(transform.position - player.transform.position);
        }

        // When dog is close to player
        else {
            direction = Vector2.zero;
        }
    }

    private void SitPositionCalculations() {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition;
    }

    private void MoveDog() {
        if(guardingPlayer) {
            body.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime * 4.5f);
        }

    }

    private void FindClosestEnemy() {

        multipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform enemyPosition = null;

        foreach (GameObject obj in multipleEnemies) {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, obj.transform.position);
            if(currentDistance < closestDistance) {
                closestDistance = currentDistance;
                enemyPosition = obj.transform;
            }
        }

        if(enemyPosition != null) {
            rotateWeapon.GetClosestEnemy(enemyPosition.position);
            dontShoot = false;
        }
        else
            dontShoot = true;
    }

    private void ShootEnemies() {

        firecooldown -= Time.deltaTime;

        if(firecooldown < 0 && !dontShoot) {
            GameObject projectile = Instantiate(bullet, firePoint.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
            firecooldown = fireIntervals;
        }
    }
}
