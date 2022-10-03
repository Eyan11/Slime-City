using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GooCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    private float gooScore;

    private void Update() {
        textBox.text = "Goo: " + gooScore.ToString("0");
    }

    public void ChangeGooScore(float goo) {
        gooScore += goo;
    }
}
