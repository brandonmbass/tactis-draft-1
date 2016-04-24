using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Battlefield : MonoBehaviour {
    public int width, depth;
    public float frequency;
    public float scale;
    public Surface baseSurface;
    Surface selectedSurface;

    ArrayList[,] surfaces;
    // Use this for initialization
    void Start () {
        InitRandomly();
    }

    public void InitRandomly()
    {
        surfaces = new ArrayList[width, depth];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < width; y++)
            {
                float height = scale * Mathf.PerlinNoise( x / frequency, y / frequency);
                createSurface(x, y, height);
                createBox(x, y, height);
            }
        }
    }

    public List<Surface> shortestPath(Surface begin, Surface goal)
    {
        return null;
    }

    public void createSurface(int x, int y, float height)
    {
        if (surfaces[x, y] == null)
            surfaces[x, y] = new ArrayList();

        Surface surface = Instantiate(baseSurface, transform.position + new Vector3(x, height, y ), transform.rotation) as Surface;
        surface.transform.SetParent(transform);
        surfaces[x, y].Add(surface);

        for (int offset_x = -1; offset_x <= 1; ++offset_x)
        {
            int x_i = x + offset_x;
            if (x_i < 0 || x_i >= width)
                continue;

            for (int offset_y = -1; offset_y <= 1; ++offset_y)
            {
                int y_i = y + offset_y;
                if (offset_x == 0 && offset_y == 0)
                    continue;

                if (y_i < 0 || y_i >= width)
                    continue;

                if (surfaces[x_i, y_i] == null)
                    continue;
                    
                foreach(Surface neighbor in surfaces[x_i,y_i])
                {
                    surface.addNeighbor(neighbor);
                }
            }
        }
    }

    public void createBox(int x, int y, float height)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.SetParent(transform);
        cube.transform.localPosition = new Vector3(x, height / 2 - 0.01f, y);
        cube.transform.localScale = new Vector3(1, height, 1);
    }
}
