using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private GameObject chargingAlien;
    [SerializeField] private GameObject rangedAlien;
    [SerializeField] private GameObject fastAlien;
    private Transform player;

    [Header ("Spawner Range")]
    [SerializeField] private float XMin;
    [SerializeField] private float XMax;
    [SerializeField] private float YMin;
    [SerializeField] private float YMax;

    [Header ("Spawner Settings")]
    [SerializeField] private float chargingAlienInterval;
    [SerializeField] private float rangedAlienInterval;
    [SerializeField] private float fastAlienInterval;

    private void Awake() {
        player = GameObject.FindWithTag("Player").transform;
        
        StartCoroutine(spawnEnemy(chargingAlienInterval, chargingAlien));
        StartCoroutine(spawnEnemy(rangedAlienInterval, rangedAlien));
        StartCoroutine(spawnEnemy(fastAlienInterval, fastAlien));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(interval);
        bool foundSpawnLocation = false;

        while (!foundSpawnLocation) {
            
            Vector3 enemyPosition = new Vector3(Random.Range(XMin, XMax), Random.Range(YMin, YMax), 0);

            if((enemyPosition - player.position).magnitude < 3) {
                continue;
            }
            else {
                GameObject newEnemy = Instantiate(enemy, enemyPosition, Quaternion.identity);
                foundSpawnLocation = true;
            }
        }
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
