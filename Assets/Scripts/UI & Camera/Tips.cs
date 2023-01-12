using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    private float counter = 0f;
    private float totalTipTime = 8f;

    [SerializeField] private GameObject tipsManager;

    private void Update() {
        Debug.Log(counter);

        if(PlayerPrefs.GetInt("SeenTips") == 0) {

            counter += Time.deltaTime;

            if(counter >= totalTipTime)
                PlayerPrefs.SetInt("SeenTips", 1);
        }

        if(PlayerPrefs.GetInt("SeenTips") == 1) {
            if(tipsManager == null)
                return;

            tipsManager.SetActive(false);
        }
    }
}
