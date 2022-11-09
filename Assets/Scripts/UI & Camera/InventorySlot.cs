using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image slot1Image;
    [SerializeField] private Image slot2Image;
    [SerializeField] private Image slot3Image;
    [SerializeField] private Image slot4Image;
    [SerializeField] private ShopInteraction shopScript;
    [SerializeField] private Image slot1Background;
    [SerializeField] private Image slot2Background;
    [SerializeField] private Image slot3Background;
    [SerializeField] private Image slot4Background;

    private void Update() {
        InventoryImages();

    }

    private void InventoryImages() {
        
        slot1Image.color = new Color(slot1Image.color.r, slot1Image.color.g, slot1Image.color.b, 1f);

        if(shopScript.hasChargeRifle())
            slot2Image.color = new Color(slot2Image.color.r, slot2Image.color.g, slot2Image.color.b, 1f);

        if(shopScript.hasTurtle())
            slot3Image.color = new Color(slot3Image.color.r, slot3Image.color.g, slot3Image.color.b, 1f);

        if(shopScript.hasDog())
            slot4Image.color = new Color(slot4Image.color.r, slot4Image.color.g, slot4Image.color.b, 1f);

    }

    public void HighlightSelectedSlot(int slotNum) {

        if(slotNum == 1) {
            slot1Background.color = new Color(1f, 1f, 1f, 0.3f);
            slot2Background.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
            slot3Background.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
            slot4Background.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
        }
        else if(slotNum == 2) {
            slot2Background.color = new Color(1f, 1f, 1f, 0.3f);
            slot1Background.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
            slot3Background.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
            slot4Background.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
        }
        else if(slotNum == 3) {
            slot3Background.color = new Color(1f, 1f, 1f, 0.3f);
            slot1Background.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
            slot2Background.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
            slot4Background.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
        }
        else {
            slot4Background.color = new Color(1f, 1f, 1f, 0.3f);
            slot1Background.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
            slot2Background.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
            slot3Background.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
        }
    }
}
