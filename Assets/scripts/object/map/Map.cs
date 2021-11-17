using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    [SerializeField]
    Tilemap colliderTilemap;

    bool[,] map;

    void Awake()
    {
        map = new bool[Global.MAP_HEIGHT + 2, Global.MAP_WIDTH + 2];

        // Initalize map data
        for (int i = 0; i <= Global.MAP_HEIGHT + 1; i++)
        {
            for (int j = 0; j <= Global.MAP_WIDTH + 1; j++)
            {
                map[i, j] = true;
                if (colliderTilemap.GetTile(new Vector3Int(i, j, 0)) != null)
                {
                    map[i, j] = false;
                }
            }
        }

    }

    public bool[,] GetMap()
    {
        return map;
    }
}
