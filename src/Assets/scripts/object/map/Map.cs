using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    [SerializeField]
    Tilemap colliderTilemap;

    HashSet<int>[,] map;

    Dictionary<string, List<Vector2Int>> paths;

    void Awake()
    {
        map = new HashSet<int>[Global.MAP_HEIGHT + 2, Global.MAP_WIDTH + 2];
        paths = new Dictionary<string, List<Vector2Int>>();

        // Initalize map data
        for (int i = 0; i <= Global.MAP_HEIGHT + 1; i++)
        {
            for (int j = 0; j <= Global.MAP_WIDTH + 1; j++)
            {
                map[i, j] = new HashSet<int>();
                if (colliderTilemap.GetTile(new Vector3Int(i, j, 0)) != null)
                {
                    map[i, j].Add(-1);
                }
            }
        }

    }

    public HashSet<int>[,] GetMap()
    {
        return map;
    }

    public Vector3 GetCell(Vector3 position)
    {
        return new Vector3(Mathf.Floor(position.x), Mathf.Floor(position.y), 0);
    }

    bool[,] isVisited = new bool[Global.MAP_HEIGHT + 2, Global.MAP_WIDTH + 2];
    Vector2Int[,] trace = new Vector2Int[Global.MAP_HEIGHT + 2, Global.MAP_WIDTH + 2];
    int[] dx = new int[4] { 0, 1, 0, -1 };
    int[] dy = new int[4] { 1, 0, -1, 0 };

    public Vector3 FindPathTo(string key, Vector3 src, Vector3 dst)
    {
        // Remove previous path
        RemovePath(key);

        src = GetCell(src);
        dst = GetCell(dst);

        Vector2Int s = new Vector2Int((int)src.x, (int)src.y);
        Vector2Int t = new Vector2Int((int)dst.x, (int)dst.y);

        // Initialize map
        for (int i = 1; i <= Global.MAP_HEIGHT; i++)
            for (int j = 1; j <= Global.MAP_WIDTH; j++)
                isVisited[i, j] = false;
        isVisited[s.x, s.y] = true;
        trace[s.x, s.y] = new Vector2Int(0, 0);
        trace[t.x, t.y] = new Vector2Int(0, 0);
        // Push source to queue
        Queue<Vector3Int> queue = new Queue<Vector3Int>();
        queue.Enqueue(new Vector3Int(s.x, s.y, 0));

        // BFS
        while (queue.Count > 0)
        {
            Vector3Int front = queue.Peek();
            queue.Dequeue();
            Vector2Int u = new Vector2Int(front.x, front.y);
            int du = front.z;

            if (u.x == t.x & u.y == t.y) break;

            for (int k = 0; k < 4; k++)
            {
                Vector2Int v = new Vector2Int(u.x + dx[k], u.y + dy[k]);
                if (v.x < 1 || v.y < 1 || v.x > Global.MAP_WIDTH || v.y > Global.MAP_HEIGHT) continue;
                if (isVisited[v.x, v.y]) continue;
                if (((v.x != t.x || v.y != t.y) && map[v.x, v.y].Contains(du + 1)) || map[v.x, v.y].Contains(-1)) continue;

                isVisited[v.x, v.y] = true;
                trace[v.x, v.y] = new Vector2Int(u.x, u.y);
                queue.Enqueue(new Vector3Int(v.x, v.y, du + 1));
            }
        }

        // Trace path
        List<Vector2Int> path = new List<Vector2Int>();
        Vector2Int wtf = new Vector2Int(t.x, t.y);
        while (wtf.x > 0)
        {
            path.Add(wtf);
            wtf = trace[wtf.x, wtf.y];
        }
        path.Reverse();
        if (path.Count == 1)
            return new Vector3(s.x, s.y, 0);
        else
        {
            AddPath(key, path);
            return new Vector3(path[1].x + 0.5f, path[1].y + 0.5f, 0);
        }
    }

    public void RemovePath(string key)
    {
        if (paths.ContainsKey(key))
        {
            List<Vector2Int> path = paths[key];
            paths.Remove(key);
            for (int i = 0; i < path.Count; i++)
                if (map[path[i].x, path[i].y].Contains(i))
                    map[path[i].x, path[i].y].Remove(i);
        }
    }

    public void AddPath(string key, List<Vector2Int> path)
    {
        RemovePath(key);
        paths.Add(key, path);
        for (int i = 0; i < path.Count; i++) map[path[i].x, path[i].y].Add(i);
    }

    public Vector3 GenerateNewDestination(Vector3 position)
    {
        position = GetCell(position);
        Vector2Int cell = new Vector2Int((int)position.x, (int)position.y);
        System.Random rand = new System.Random();
        while (true)
        {
            int k = rand.Next(4);
            Vector2Int dst = new Vector2Int(cell.x + dx[k], cell.y + dy[k]);
            if (dst.x < 1 || dst.y < 1 || dst.x > Global.MAP_WIDTH || dst.y > Global.MAP_HEIGHT) continue;
            if (map[dst.x, dst.y].Contains(-1)) continue;
            return new Vector3(dst.x + 0.5f, dst.y + 0.5f, 0);
        }
    }
}
