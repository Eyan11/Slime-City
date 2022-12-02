using UnityEngine;

public class RotateDogGun : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Transform dog;
    [SerializeField] private Animator anim;
    private Rigidbody2D body;
    private Vector3 aimDirection;
    private float dogVelocity;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        RotateGun();
    }

    private void Update() {
        //Animations
        anim.SetFloat("Direction", body.rotation);
    }

    public void RotateGun() {
        
        if(aimDirection != null) {
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            body.rotation = aimAngle;
        }

        transform.position = dog.transform.position;
    }

    public void GetClosestEnemy(Vector3 _enemyPosition) {
        aimDirection = _enemyPosition - dog.transform.position;
    }
}
