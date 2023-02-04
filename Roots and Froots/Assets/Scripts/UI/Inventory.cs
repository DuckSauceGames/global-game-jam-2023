using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using System.Linq;

public class Inventory : MonoBehaviour
{

    public List<GameObject> slots;
    public GameObject slot;

    // Start is called before the first frame update
    void Start()
    {
        var vegetables = System.Enum.GetValues(typeof(Veg.Vegetable)).Cast<Veg.Vegetable>().ToList();
        foreach (var veg in vegetables)
        {
            var slotInstance = GameObject.Instantiate(slot);
            string slotName;
            if (veg == Veg.Vegetable.CARROT) {
                slotName = "carrot";
            } else if (veg == Veg.Vegetable.ONION) {
                slotName = "onion";
            } else {
                slotName = "potato";
            }
            slotInstance.name = slotName;
            slots.Add(slotInstance);
            slotInstance.transform.SetParent(transform);
        }
    }

    public void SetVegInventory(Veg.Vegetable veg, int number){
        foreach (GameObject slot in slots)
        {
            if (slot.name == veg.ToString().ToLower()) {
                slot.GetComponent<Slot>().SetCounter(number);
            }
        }
    }

    public int GetVegInventory(Veg.Vegetable veg) {
        foreach (GameObject slot in slots) {
            if (slot.name == veg.ToString().ToLower()) {
                return slot.GetComponent<Slot>().GetCounter();
            }
        }
        return 0;
    }
}
