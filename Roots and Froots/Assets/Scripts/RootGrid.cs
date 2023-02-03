using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootGrid : MonoBehaviour {

    public int width = 25;
    public int height = 100;

    public GameObject potato;
    public int potatoCount = 20;

    public GameObject carrot;
    public int carrotCount = 10;

    public GameObject onion;
    public int onionCount = 5;

    private List<List<GameObject>> grid = new List<List<GameObject>>();
    
    void Start() {
        List<GameObject> column = new List<GameObject>();
        for (int i = 0; i < height; i++) column.Add(null);
        for (int i = 0; i < width; i++) grid.Add(column);

        plantVeg(potato, potatoCount);
        plantVeg(carrot, carrotCount);
        plantVeg(onion, onionCount);
    }

    private void plantVeg(GameObject veg, int count) {
        for (int i = 0; i < count; i++) {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            if (grid[x][y] == null)
                grid[x][y] = GameObject.Instantiate(veg, new Vector2(x/10f, y/10f), Quaternion.identity, this.transform);
        }
    }
}
