using UnityEngine;

public class GooCollectable : MonoBehaviour
{
    private GooCounter gooScoreCounter;
    [SerializeField] private float moveToPlayerDistance;
    [SerializeField] private float speed;
    private float gooAmount;
    private Transform player;

    private void Awake() {
        player = GameObject.FindWithTag("Player").transform;
        gooScoreCounter = GameObject.Find("Goo Counter").GetComponent<GooCounter>();
    }

    private void Start() {
        if (transform.localScale == Vector3.one * 2) {
            gooAmount = 5;
        }
        else if (transform.localScale == Vector3.one * 3) {
            gooAmount = 10;
        }
        else {
            gooAmount = 15;
        }
    }
    
    private void Update() {
        if(Vector2.Distance(transform.position, player.position) < moveToPlayerDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player") {
            gooScoreCounter.ChangeGooScore(gooAmount);
            Destroy(gameObject);
        }
    }
}
