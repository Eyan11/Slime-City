using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private GameObject rotationPoint;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D body;
    private float playerVelocity;

    private void Update() {
        anim.SetFloat("MousePosition", rotationPoint.GetComponent<Rigidbody2D>().rotation);

        playerVelocity = Mathf.Abs(body.velocity.x) + Mathf.Abs(body.velocity.y);
        anim.SetBool("isIdle", playerVelocity == 0);
    }
}
