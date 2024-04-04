using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] mappings;
    public float segmentSize = 5;

    public void Clear()
    {
        for( int i=transform.childCount-1; i>=0; i-- )
        {
            DestroyImmediate( transform.GetChild(i).gameObject );
        }
    }

    public void Generate()
    {
        for(int x=0; x<map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                Color c = map.GetPixel(x,y);
                Vector3 position = new Vector3(x, 0, y) * segmentSize;
                position = transform.TransformPoint(position);
                foreach(ColorToPrefab pair in mappings)
                {
                    if(pair.color == c)
                    {
                        Instantiate(pair.prefab, position, Quaternion.identity, transform);
                    }
                }
            }
        }
    }

    [Serializable]
    public class ColorToPrefab
    {
        public Color color;
        public GameObject prefab;
    }
}
