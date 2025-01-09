using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    public GameObject treasurePrefab;
    int n = 50;

    void Start()
    {
        for (int t = 0; t < n; t++)
        {
            int i = Random.Range(0,WorldBuilder.size);
            int j = Random.Range(0, WorldBuilder.size);
            float y = WorldBuilder.height[i, j];
            float offset = 0f;
            if (j % 2 != 0)
            {
                offset = 0.5f;
            }
            float x = i + offset;
            float z = j * 0.86602f;
            Vector3 pos = new Vector3(x, y + 1f, z);
            Instantiate(treasurePrefab, pos, Quaternion.identity);
            
        }
    }
}
