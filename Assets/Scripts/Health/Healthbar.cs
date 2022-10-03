using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Health playerHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;
    private void Awake()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        totalHealthbar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currentHealthbar.fillAmount = playerHealth.currentHealth / 10;
    }
}
