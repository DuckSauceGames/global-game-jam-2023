using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start() {
        text = transform.GetComponent<TextMeshProUGUI>();
        SetCurrencyValue(0);
    }
    public void SetCurrencyValue(int value) {
        string curr_name;
        if (value == 1) {
            curr_name = "groat";
        } else {
            curr_name = "groats";
        }
        text.text = value.ToString() + " " + curr_name;
    }
}
