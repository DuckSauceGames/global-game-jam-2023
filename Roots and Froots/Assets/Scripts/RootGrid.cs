using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootGrid : MonoBehaviour {

    public int width = 100;
    public int height = 100;

    [System.Serializable]
    public class VegDetails {
        public Veg.Vegetable type;
        public GameObject prefab;
        public int maxCount;
        public int respawnChance;

        private int currentCount;
        
        public int Count() { return currentCount; }
        public void IncreaseCount() { currentCount++; }
        public void DecreaseCount() { currentCount--; }
    }

    public List<VegDetails> allVegDetails;

    private List<List<GameObject>> grid = new List<List<GameObject>>();
    
    void Start() {
        List<GameObject> column = new List<GameObject>();
        for (int i = 0; i < height; i++) column.Add(null);
        for (int i = 0; i < width; i++) grid.Add(column);

        allVegDetails.ForEach(v => PlantInitialVeg(v));
    }

    void Update() {
        allVegDetails.ForEach(v => RespawnVeg(v));
    }

    private void PlantInitialVeg(VegDetails vegDetails) {
        for (int i = 0; i < vegDetails.maxCount; i++) {
            PlantVeg(vegDetails);
        }
    }

    private void PlantVeg(VegDetails vegDetails) {
        int x = Random.Range(0, width);
        int y = Random.Range(0, height);
        if (grid[x][y] == null) {
            grid[x][y] = GameObject.Instantiate(vegDetails.prefab, new Vector2(x, y + transform.position.y), Quaternion.identity, this.transform);
            vegDetails.IncreaseCount();
        }
    }

    private void RespawnVeg(VegDetails vegDetails) {
        if (vegDetails.Count() < vegDetails.maxCount && Random.Range(1, vegDetails.respawnChance) == 1) PlantVeg(vegDetails);
    }

    public void CollectVeg(GameObject vegObject) {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (grid[x][y] == vegObject) {
                    Veg veg = vegObject.GetComponent<Veg>();

                    foreach (VegDetails vegDetails in allVegDetails) {
                        if (vegDetails.type == veg.type) vegDetails.DecreaseCount();
                    }

                    Destroy(vegObject);

                    return;
                }
            }
        }
    }
}
