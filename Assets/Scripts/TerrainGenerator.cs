using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    None,
    Forest,
    Grass,
    Ice,
    Mountain,
    Sand,
    Water
}

public class TerrainGenerator : SerializedMonoBehaviour
{
    [SerializeField]
    private Dictionary<TileType, Tile> tilesPrefab = new Dictionary<TileType, Tile>();

    private void Start()
    {
        GenerateTerrain();
    }

    private void GenerateTerrain()
    {
        
    }
}
