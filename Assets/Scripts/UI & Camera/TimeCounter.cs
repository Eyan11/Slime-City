using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textBox;
    private Health playerHealth;
    private float score;

    private void Awake() {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }
    private void Update() {
        if(playerHealth.currentHealth > 0) {
            score += Time.deltaTime;
        }
        textBox.text = "Time: " + score.ToString("0");
    }
}
