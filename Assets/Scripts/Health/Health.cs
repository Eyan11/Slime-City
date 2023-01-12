using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private bool dead = false;
    
    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    
    [Header ("Components To Disable")]
    [SerializeField] private Behaviour[] components;
    [SerializeField] private GameObject[] objects;
    private Rigidbody2D body;

    [Header ("Animations")]
    [SerializeField] private Animator anim;

    private void Awake() {
        currentHealth = startingHealth;
        body = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage) {

        currentHealth = Mathf.Clamp(currentHealth -_damage, 0, startingHealth);
        
        if(currentHealth > 0) {
            StartCoroutine(Invulnerability());
        }
        else {
            anim.SetBool("Die", true);
        }
    }

    private void Death() {
        if (!dead) {
            foreach (Behaviour component in components) {
                component.enabled = false;
            }

            foreach (GameObject gameObject in objects) {
                Destroy(gameObject);
            }

            if(GetComponent<GooSpawner>() != null) {
                GetComponent<GooSpawner>().SpawnGoo();
            }
            
            Destroy(gameObject);
            dead = true;
        }
    }

    private IEnumerator Invulnerability() {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numberOfFlashes; i++) {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    public void addHeart() {
        currentHealth += 1;
    }
}
