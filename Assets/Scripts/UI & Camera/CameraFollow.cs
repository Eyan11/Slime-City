using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;

    private void Awake() {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate() {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, -10);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
