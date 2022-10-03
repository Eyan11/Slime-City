using UnityEngine;

public class RangedAlienFirepointRotation : MonoBehaviour
{
    public void RotateFirePoint(float angle) {
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0.0f, 0.0f, angle));
    }
}
