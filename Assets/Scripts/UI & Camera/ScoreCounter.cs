using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private GameOverScore gameOverScore;
    private Health playerHealth;
    private float score;

    private void Awake() {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }
    private void Update() {
        if(playerHealth.currentHealth > 0) {
            score += Time.deltaTime * 1.5f;
        }
        else {
            gameOverScore.RecieveScore(score);
        }
        textBox.text = "Score: " + score.ToString("0");

    }

    public void EliminationScore(float elimScore) {
        score += elimScore;
    }

}
