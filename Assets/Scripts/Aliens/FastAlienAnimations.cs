using UnityEngine;

public class FastAlienAnimations : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void GetDirectionAngle(float direction) {
        anim.SetFloat("Direction", direction);
    }
}
