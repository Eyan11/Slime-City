using UnityEngine;

public class TurtlePulse : MonoBehaviour
{
    [Header ("Settings")]
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Trigger Colliding");

        if(collider.tag == "Enemy") {

            collider.GetComponent<Health>().TakeDamage(damage);
            Debug.Log("Colliding With Enemy");
        }
    }
}
