using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GooCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [HideInInspector] public float gooScore;
    [SerializeField] private ScoreCounter scoreCounter;

    private void Update() {
        textBox.text = "Goo: " + gooScore.ToString("0");
    }

    public void ChangeGooScore(float goo) {
        gooScore += goo;
        scoreCounter.EliminationScore(goo/5f);
    }
}
