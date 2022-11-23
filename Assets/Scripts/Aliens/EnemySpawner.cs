using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private GameObject chargingAlien;
    [SerializeField] private GameObject rangedAlien;
    [SerializeField] private GameObject fastAlien;
    private Transform player;
    private float timeAlive = 0f;
    private bool waveTwo = false;
    private bool waveThree = false;
    private bool waveFour = false;
    private bool waveFive = false;

    [Header ("Spawner Range")]
    [SerializeField] private float XMin;
    [SerializeField] private float XMax;
    [SerializeField] private float YMin;
    [SerializeField] private float YMax;

    [Header ("Spawner Settings")]
    [SerializeField] private float chargingAlienInterval;
    [SerializeField] private float rangedAlienInterval;
    [SerializeField] private float fastAlienInterval;
    [SerializeField] private float waveTwoTime;
    [SerializeField] private float waveThreeTime;
    [SerializeField] private float waveFourTime;
    [SerializeField] private float waveFiveTime;

    private void Awake() {
        player = GameObject.FindWithTag("Player").transform;
        
        StartCoroutine(spawnEnemy(chargingAlienInterval, chargingAlien));
        StartCoroutine(spawnEnemy(rangedAlienInterval, rangedAlien));
        StartCoroutine(spawnEnemy(fastAlienInterval, fastAlien));
    }

    private void Update() {
        timeAlive += Time.deltaTime;
        
        if (timeAlive > waveTwoTime && !waveTwo) {
            StartCoroutine(spawnEnemy(chargingAlienInterval, chargingAlien));
            StartCoroutine(spawnEnemy(rangedAlienInterval, rangedAlien));
            StartCoroutine(spawnEnemy(fastAlienInterval, fastAlien));
            waveTwo = true;
        }
        else if (timeAlive > waveThreeTime && !waveThree) {
            StartCoroutine(spawnEnemy(chargingAlienInterval, chargingAlien));
            StartCoroutine(spawnEnemy(rangedAlienInterval, rangedAlien));
            StartCoroutine(spawnEnemy(fastAlienInterval, fastAlien));
            waveThree = true;
        }
        else if (timeAlive > waveFourTime && !waveFour) {
            StartCoroutine(spawnEnemy(chargingAlienInterval, chargingAlien));
            StartCoroutine(spawnEnemy(rangedAlienInterval, rangedAlien));
            StartCoroutine(spawnEnemy(fastAlienInterval, fastAlien));
            waveFour = true;
        }
        else if (timeAlive > waveFiveTime && !waveFive) {
            StartCoroutine(spawnEnemy(chargingAlienInterval, chargingAlien));
            StartCoroutine(spawnEnemy(rangedAlienInterval, rangedAlien));
            StartCoroutine(spawnEnemy(fastAlienInterval, fastAlien));
            waveFive = true;
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(interval);
        bool foundSpawnLocation = false;

        while (!foundSpawnLocation) {
            
            Vector3 enemyPosition = new Vector3(Random.Range(XMin, XMax), Random.Range(YMin, YMax), 0);

            if((enemyPosition - player.position).magnitude > 5) {
                GameObject newEnemy = Instantiate(enemy, enemyPosition, Quaternion.identity);
                foundSpawnLocation = true;
            }

        }
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
