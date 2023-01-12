using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;

    public void RecieveScore(float finalScore) {

        if(finalScore > PlayerPrefs.GetFloat("HighScore", 0)) {
            PlayerPrefs.SetFloat("HighScore", finalScore);
        }

        textBox.text = "Score: " + finalScore.ToString("0") + "\nHighScore: " + PlayerPrefs.GetFloat("HighScore").ToString("0");
    }
}
