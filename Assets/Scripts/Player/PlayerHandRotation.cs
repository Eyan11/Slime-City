using UnityEngine;

public class PlayerHandRotation : MonoBehaviour
{
    private Rigidbody2D body;
    private Camera sceneCamera;
    private Transform player;
    private Vector2 mousePosition;

    private void Awake() {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
        sceneCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Update() {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate() {
        Vector2 aimDirection = mousePosition - body.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        body.rotation = aimAngle;

        transform.position = player.position;
    }
}
