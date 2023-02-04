using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(UIDocument))]
public class Shop : MonoBehaviour
{
    public string _itemName;
    public int _shopPrice;
    public bool _isExpendable;

    // Amount of stacked instances of this buff are on the worm
    // i.e. potential for stacking speed buffs - maybe diminishing returns?
    public int amountActive = 0;
    
    public bool buy(Worm worm) {
        worm.speed += 5;


        // Check to see if player has enough currency
        if (worm.money >= _shopPrice) {
            worm.money -= _shopPrice;
            amountActive += 1;
            return true;
        }
        else {return false;}

    }
    
}
