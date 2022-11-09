using UnityEngine;

public class TurtlePulse : MonoBehaviour
{
    [Header ("Settings")]
    [SerializeField] private float damage;

    private void OnTriggerStay2D(Collider2D collider) {

        if(collider.tag == "Enemy") {

            collider.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
