using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldBuilder : MonoBehaviour
{
    float phaseX;
    float phaseZ;
    public static int size = 100;
    public GameObject[] hexPrefabs = new GameObject[10];
    public GameObject[] objPrefabs = new GameObject[10];
    public GameObject[] plantPrefabs = new GameObject[3];
    public static float[,] height;
    // Start is called before the first frame update
    void Awake()
    {
        height = new float[size, size];
        phaseX = Random.Range(-1000f, 1000f);
        phaseZ = Random.Range(-1000f, 1000f);
        for (int j = 0; j < size; j++)
        {

            for (int i = 0; i < size; i++)
            {
                float offset = 0f;
                if (j % 2 != 0)
                {
                  offset = 0.5f;
                }
                float x = i + offset;
                float z = j * 0.86602f;
                float y = GetHeight(x, z, phaseX, phaseZ);
                height[i, j] = y;

                Vector3 pos = new Vector3(x, y, z);
                if (y < -0.3f)//water
                {
                    if (y < -0.5f)
                    {
                        Instantiate(hexPrefabs[1], pos, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(hexPrefabs[9], pos, Quaternion.identity);
                    }
                    if (Random.Range(0,50) == 0)
                    {
                        Instantiate(objPrefabs[0], pos, Quaternion.identity);
                    }
                }
                else if (y < -0.2f)//sand
                {
                    Instantiate(hexPrefabs[5], pos, Quaternion.identity);
                    if (Random.Range(0,10) == 0)
                    {
                        Instantiate(objPrefabs[8], pos, Quaternion.identity);
                    }
                }
                else if (y < 0.5f)//grass
                {
                    Instantiate(hexPrefabs[Random.Range(2, 5)], pos, Quaternion.identity);
                    if (Random.Range(0, 30) == 0)
                    {
                        Instantiate(objPrefabs[3], pos, Quaternion.identity);
                    }
                    else if (Random.Range(0, 40) == 1)
                    {
                        Instantiate(objPrefabs[4], pos, Quaternion.identity);
                    }
                    else if (Random.Range(0, 30) == 2)
                    {
                        Instantiate(objPrefabs[5], pos, Quaternion.identity);
                    }
                    else if (Random.Range(0, 30) == 2)
                    {
                        Instantiate(objPrefabs[0], pos, Quaternion.identity);
                    }
                }
                else//mountains
                {
                    Instantiate(hexPrefabs[Random.Range(6,9)], pos, Quaternion.identity);
                    if (Random.Range(0, 30) == 0)
                    {
                        Instantiate(objPrefabs[1], pos, Quaternion.identity);
                    }
                    else if (Random.Range(0, 100) == 1)
                    {
                        Instantiate(objPrefabs[6], pos, Quaternion.identity);
                    }
                    else if (Random.Range(0, 30) == 2)
                    {
                        Instantiate(objPrefabs[7], pos, Quaternion.identity);
                    }
                    else if (Random.Range(0, 30) == 2)
                    {
                        Instantiate(objPrefabs[9], pos, Quaternion.identity);
                    }
                }
                
            }
        }
    }



    float GetHeight(float x, float z, float phaseX, float phaseZ) //calculate perlin noise height
    {
        float h = 0f;
        float ampl = 3f, freq = 0.05f;

        for (int oct = 0; oct < 4; oct++)
        {
            h += ampl * (Mathf.PerlinNoise(freq * x + phaseX, freq * z + phaseZ) - 0.5f);
            ampl /= 2f;
            freq *= 2f;
        }

        return h;

    }

 
}
