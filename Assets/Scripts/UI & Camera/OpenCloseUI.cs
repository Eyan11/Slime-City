using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseUI : MonoBehaviour
{
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private GameObject gameOver;
    private bool isShopping = false;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Tab))
            isShopping = !isShopping;

        if(isShopping)
            shopMenu.SetActive(true);
        else
            shopMenu.SetActive(false);


        if(GameObject.FindWithTag("Player") == null) {
            gameOver.SetActive(true);
            isShopping = false;
        }
        else
            gameOver.SetActive(false);
    }
}
