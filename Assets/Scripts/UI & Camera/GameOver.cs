using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Image overlay;
    [SerializeField] private GameObject shopMenuObject;
    [SerializeField] private GameObject UIObject;
    private float alpha = 0f;
    private void Update() {
        if(alpha < 0.9)
            alpha += Time.deltaTime * 0.1f;

        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, alpha);
        FindObjectOfType<AudioManager>().Pause("RayGunBeam");

        shopMenuObject.SetActive(false);
        UIObject.SetActive(false);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
