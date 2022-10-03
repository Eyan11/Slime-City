using UnityEngine;

public class PlayerProjectileDamage : MonoBehaviour
{
    [SerializeField] private float damage = 1;

    private void OnTriggerEnter2D(Collider2D collider) {
        
        if(collider.tag != "Player" && collider.tag != "Projectile" && collider.tag != "Friendly") {
            Destroy(gameObject);
        }
        
        if(collider.tag == "Enemy") {
            collider.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
