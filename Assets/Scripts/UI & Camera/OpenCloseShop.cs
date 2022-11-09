using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseShop : MonoBehaviour
{
    [SerializeField] private GameObject shopMenu;
    private bool isShopping = false;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Tab))
            isShopping = !isShopping;


        if(isShopping)
            shopMenu.SetActive(true);
        else
            shopMenu.SetActive(false);
    }
}
