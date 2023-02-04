using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public string _itemName;
    public int _shopPrice;
    public bool _isExpendable;

    // Amount of stacked instances of this buff are on the worm
    // i.e. potential for stacking speed buffs - maybe diminishing returns?
    public int amountActive = 0;

    public Shop(string itemName, int shopPrice, bool isExpendable)
    {
        _itemName = itemName;
        _shopPrice = shopPrice;
        _isExpendable = isExpendable;
    }

    public bool buy()
    {
        // Placeholder
        int currency = 100;

        // Check to see if player has enough currency
        if (currency >= _shopPrice)
        {
            currency -= _shopPrice;
            amountActive += 1;
            return true;
        }
        else {return false;}

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
