using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Worm : MonoBehaviour
{

    private class VegDetails {
        public Veg.Vegetable type;
        public int currentCount;

        public int currentSaved;

        public VegDetails(Veg.Vegetable type) { this.type = type; }
    }

    private List<VegDetails> allVegDetails;

    private int maxVegCount = 5;

    public RootGrid rootGrid;

    private SpriteRenderer spi;

    public GameObject inventory;

    public GameObject currencyUI;

    public int money = 0;

    public GameObject sound;

    public GameObject statsBar;

    public int vegCost = 100;

    public float stamina;

    private Shop currentShop;
    public List<Shop> allShops;

    public int speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        allVegDetails = new List<VegDetails>();
        System.Enum.GetValues(typeof(Veg.Vegetable)).Cast<Veg.Vegetable>().ToList().ForEach(v => allVegDetails.Add(new VegDetails(v)));

        spi = GetComponent<SpriteRenderer>();
        stamina = 100;
        statsBar.GetComponent<StatsBar>().stamina.GetComponent<StatBar>().SetMaxVal(Mathf.RoundToInt(stamina));
        statsBar.GetComponent<StatsBar>().stamina.GetComponent<StatBar>().SetVal(Mathf.RoundToInt(stamina));
    }

    //public Vector2 speed = new Vector2(5,5);

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (stamina > 0) {
            Vector3 movement = new Vector3(speed * inputX, speed * inputY, 0);
            //Vector3 movement = new Vector3(inputX, inputY, 0);
            movement *= Time.deltaTime;
            transform.Translate(movement);
            //transform.Rotate();
            if (inputX < 0) {spi.flipX = true;}
            if (inputX > 0) {spi.flipX = false;}
            //Debug.Log($"{speed.x} {speed.y}");

            stamina -= Time.deltaTime;
            statsBar.GetComponent<StatsBar>().stamina.GetComponent<StatBar>().SetVal(Mathf.RoundToInt(stamina));
        } else {
            Debug.Log("You Ded");
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Buying shit");
            currentShop.buy(this);
        }

        SetInventoryCounts();
        SetCurrencyCounts();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Veg veg = collider.gameObject.GetComponent<Veg>();
        string gameObjectName = collider.gameObject.name;

        if (veg != null) {
            if (GetCurrentVegCount() >= maxVegCount) return;

            rootGrid.CollectVeg(collider.gameObject);

            sound.transform.Find("Veg Pickup").GetComponent<AudioSource>().Play();

            foreach (VegDetails vegDetails in allVegDetails) {
                if (vegDetails.type == veg.type) vegDetails.currentCount++;
            }
            return;
        }
        if (gameObjectName == "Farm") {
            foreach (VegDetails vegDetails in allVegDetails) {
                vegDetails.currentSaved = vegDetails.currentCount;
                money += vegDetails.currentCount * vegCost;
                vegDetails.currentCount = 0;
            }
            stamina = 100;
            statsBar.GetComponent<StatsBar>().stamina.GetComponent<StatBar>().SetVal(Mathf.RoundToInt(stamina));
            SetInventoryCounts();
            return;
        }

        Shop shop = collider.gameObject.GetComponent<Shop>();
        if (shop != null) {
            Debug.Log("Set shop yo");
            currentShop = shop;
            return;
        }

        Debug.Log("idk what i'm colliding with");

    }

    private void OnTriggerExit2D(Collider2D other) {
        currentShop = null;
    }

    private int GetCurrentVegCount() {
        int count = 0;
        foreach (VegDetails vegDetails in allVegDetails) count += vegDetails.currentCount;
        return count;
    }

    private void SetCurrencyCounts() {
        currencyUI.GetComponent<Currency>().SetCurrencyValue(money);
    }

    private void SetInventoryCounts() {
        foreach (VegDetails vegDetails in allVegDetails) {
            inventory.GetComponent<Inventory>().SetVegInventory(vegDetails.type, vegDetails.currentCount);
        }
    }
}
