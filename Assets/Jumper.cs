using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    float lastTime;
    int facingHex = 0;
    Vector2Int[] adjacent;
    float offset = 0f;
    Vector2Int pos;

    void Start()
    {
        //time(sec) when game start
        lastTime = Time.time;

        int i = Random.Range(0, WorldBuilder.size);
        int j = Random.Range(0, WorldBuilder.size);
        float y = WorldBuilder.height[i, j];
        if (j % 2 != 0)
        {
            offset =  0.5f;
        }
        float x = i + offset;
        float z = j * 0.86602f;

        transform.position = new Vector3(x, y + 1f, z);

        //send info to method
        pos = new Vector2Int(i, j);
        adjacent = AdjHexes(pos);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) && (Time.time - lastTime > 0.5f))
        {
            transform.Rotate(0f, 60f, 0f);
            lastTime = Time.time;
            facingHex++;
            if (facingHex == 6)
            {
                facingHex = 0;
            }
        }

        if (Input.GetKey(KeyCode.A) && (Time.time - lastTime > 0.5f))
        {
            transform.Rotate(0f, -60f, 0f);
            lastTime = Time.time;
            facingHex--;
            if (facingHex == -1)
            {
                facingHex = 5;
            }
        }
        if (Input.GetKey(KeyCode.J) && (Time.time - lastTime > 0.5f))
        {
            adjacent = AdjHexes(pos);
            Debug.Log(pos + " " + adjacent[facingHex] + " " + facingHex);

            Vector2Int hexToMove = adjacent[facingHex];
            float x = hexToMove.x + offset;
            float z = hexToMove.y * 0.86602f;
            float y = WorldBuilder.height[hexToMove.x, hexToMove.y] + 0.40f;
            transform.position = new Vector3(x, y,z);
            facingHex = 0;
            lastTime = Time.time;
            pos = hexToMove;
        }
    }

    public void OnClick()
    {
        Application.Quit();
    }

    Vector2Int[] AdjHexes(Vector2Int pos) //find all 6 adjacent hexes to pos
    {
        Vector2Int[] adj = new Vector2Int[6];

        adj[0] = pos.y % 2 == 0 ? pos + new Vector2Int(0, 1) : pos + new Vector2Int(1, 1);      //ne neighbour
        adj[1] = pos + new Vector2Int(1, 0);                                                    //E neighbour
        adj[2] = pos.y % 2 == 0 ? pos + new Vector2Int(0, -1) : pos + new Vector2Int(1, -1);    //se neighbour
        adj[3] = pos.y % 2 == 0 ? pos + new Vector2Int(-1, -1) : pos + new Vector2Int(0, -1);   //sw neighbour
        adj[4] = pos + new Vector2Int(-1, 0);                                                   //W neighbour
        adj[5] = pos.y % 2 == 0 ? pos + new Vector2Int(-1, 1) : pos + new Vector2Int(0, 1);     //nw neighbour

        return adj;
    }

}
