using UnityEngine;

public class RayGunBeam : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float slownessPercent;
    private void OnTriggerStay2D(Collider2D collider) {
        if(collider.tag == "Enemy") {
            collider.GetComponent<Health>().TakeDamage(damage);
            if(collider.name == "Fast Alien") {
                collider.GetComponent<FastAlienMotor>().slownessEffect = slownessPercent;
            }
            if(collider.name == "Ranged Alien") {
                collider.GetComponent<RangedAlienMotor>().slownessEffect = slownessPercent;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collider) {
        if(collider.tag == "Enemy") {
            if(collider.name == "Fast Alien") {
                collider.GetComponent<FastAlienMotor>().slownessEffect = 1f;
            }
            if(collider.name == "Ranged Alien") {
                collider.GetComponent<RangedAlienMotor>().slownessEffect = 1f;
            }
        }
    }
}
