using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInteraction : MonoBehaviour
{
    [Header ("Settings")]
    [SerializeField] private int dogCost;
    [SerializeField] private int turtleCost;
    [SerializeField] private int chargeRifleCost;

    [Header ("References")]
    [SerializeField] private GameObject dogObject;
    [SerializeField] private GameObject turtleObject;
    [SerializeField] private Image dogImage;
    [SerializeField] private Image turtleImage;
    [SerializeField] private Image chargeRifleImage;
    [SerializeField] private GameObject checkDogImage;
    [SerializeField] private GameObject checkTurtleImage;
    [SerializeField] private GameObject checkChargeRifleImage;
    private GooCounter gooScript;
    private Transform playerTrans;
    private bool purchasedDog = false;
    private bool purchasedTurtle = false;
    private bool purchasedChargeRifle = false;


    private void Awake() {
        gooScript = GameObject.Find("Goo Counter").GetComponent<GooCounter>();
        playerTrans = GameObject.FindWithTag("Player").transform;
    }

    public void BuyDog() {
        if(gooScript.gooScore < dogCost)
            return;
        if(purchasedDog)
            return;
        
        gooScript.gooScore -= dogCost;
        Instantiate(dogObject, playerTrans.position, Quaternion.identity);

        dogImage.color = new Color(dogImage.color.r, dogImage.color.g, dogImage.color.b, 0.5f);
        checkDogImage.SetActive(true);
        purchasedDog = true;
    }

    public void BuyTurtle() {
        if(gooScript.gooScore < turtleCost)
            return;
        if(purchasedTurtle)
            return;
        
        gooScript.gooScore -= turtleCost;
        Instantiate(turtleObject, playerTrans.position, Quaternion.identity);

        turtleImage.color = new Color(turtleImage.color.r, turtleImage.color.g, turtleImage.color.b, 0.5f);
        checkTurtleImage.SetActive(true);
        purchasedTurtle = true;
    }

    public void BuyChargeRifle() {
        if(gooScript.gooScore < chargeRifleCost)
            return;
        if(purchasedChargeRifle)
            return;
        
        gooScript.gooScore -= chargeRifleCost;

        chargeRifleImage.color = new Color(turtleImage.color.r, turtleImage.color.g, turtleImage.color.b, 0.5f);
        checkChargeRifleImage.SetActive(true);
        purchasedChargeRifle = true;
    }

    public bool hasTurtle() {
        if(purchasedTurtle)
            return true;
        else
            return false;
    }

    public bool hasDog() {
        if(purchasedDog)
            return true;
        else
            return false;
    }

    public bool hasChargeRifle() {
        if(purchasedChargeRifle)
            return true;
        else
            return false;
    }
    
}
