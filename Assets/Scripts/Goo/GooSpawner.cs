using UnityEngine;

public class GooSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gooCollectable; 

    public void SpawnGoo() {
        Instantiate(gooCollectable, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("EnemyDeath"); 
    }
}
