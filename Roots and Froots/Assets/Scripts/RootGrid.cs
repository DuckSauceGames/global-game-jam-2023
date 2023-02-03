using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootGrid : MonoBehaviour {

    public int width = 25;
    public int height = 100;

    [System.Serializable]
    public class VegDetails {
        public GameObject prefab;
        public int maxCount;
        public int respawnChance;

        private int currentCount;
        
        public int Count() { return currentCount; }
        public void IncreaseCount() { currentCount++; }
        public void DecreaseCount() { currentCount--; }
    }

    public VegDetails potatoDetails;
    public VegDetails carrotDetails;
    public VegDetails onionDetails;

    private List<List<GameObject>> grid = new List<List<GameObject>>();
    
    void Start() {
        List<GameObject> column = new List<GameObject>();
        for (int i = 0; i < height; i++) column.Add(null);
        for (int i = 0; i < width; i++) grid.Add(column);

        plantInitialVeg(potatoDetails);
        plantInitialVeg(carrotDetails);
        plantInitialVeg(onionDetails);
    }

    void Update() {
        respawnVeg(potatoDetails);
        respawnVeg(carrotDetails);
        respawnVeg(onionDetails);
    }

    private void plantInitialVeg(VegDetails vegDetails) {
        for (int i = 0; i < vegDetails.maxCount; i++) {
            plantVeg(vegDetails);
        }
    }

    private void plantVeg(VegDetails vegDetails) {
        int x = Random.Range(0, width);
        int y = Random.Range(0, height);
        if (grid[x][y] == null) {
            grid[x][y] = GameObject.Instantiate(vegDetails.prefab, new Vector2(x/10f, y/10f), Quaternion.identity, this.transform);
            vegDetails.IncreaseCount();
        }
    }

    private void respawnVeg(VegDetails vegDetails) {
        if (vegDetails.Count() < vegDetails.maxCount && Random.Range(1, vegDetails.respawnChance) == 1) plantVeg(vegDetails);
    }
}
