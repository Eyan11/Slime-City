using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;

    public void RecieveScore(float finalScore) {
        textBox.text = "Score: " + finalScore.ToString("0");
        //Add high score
    }

    

}
