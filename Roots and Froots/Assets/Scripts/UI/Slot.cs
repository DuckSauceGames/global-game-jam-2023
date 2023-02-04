using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    private int itemCounter;
    public GameObject textComponent;
    private TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        itemCounter = 0;
        text = textComponent.GetComponent<TextMeshPro>();
        text.text = "x" + itemCounter;
    }

    public int GetCounter() {
        return itemCounter;
    }

    public void SetCounter(int counter) {
        itemCounter = counter;
        text.text = "x" + itemCounter;
    }
}
