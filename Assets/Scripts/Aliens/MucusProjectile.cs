using UnityEngine;

public class MucusProjectile : MonoBehaviour
{
    [SerializeField] private float damage = 1;
    [SerializeField] private float slownessPercent;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag != "Enemy" && collider.tag != "Projectile") {
            Destroy(gameObject);
        }
        if(collider.tag == "Player") {
            collider.GetComponent<Health>().TakeDamage(damage);
            collider.GetComponent<PlayerController>().slownessEffect = slownessPercent;
            collider.GetComponent<PlayerController>().Invoke("StopSlowness", 3);
        }
    }
}
