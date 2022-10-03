using UnityEngine;

public class Patrol : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Transform moveSpot;
    private Animator anim;

    [Header ("Patrol Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float startIdleTime;
    private float idleTimer;
    private bool stopMoving = false;
    
    [Header ("Patrol Constraints")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private void Awake() {
        anim = GetComponent<Animator>();
        
        idleTimer = startIdleTime;

        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
    
    private void Update()
    {
        float angle = Mathf.Atan2(moveSpot.position.y, moveSpot.position.x) * Mathf.Rad2Deg - 90;
        anim.SetFloat("Direction", angle);
        
        if(!stopMoving)
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f) {

            if(idleTimer <= 0) {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                idleTimer = startIdleTime;
            }
            else {
                idleTimer -= Time.deltaTime;
            }
        }
    }

    private void StopMoving() {
        stopMoving = true;
    }
}
