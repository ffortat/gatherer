using System;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField]
    private Tile forestTile = null;
    [SerializeField]
    private Tile grassTile = null;
    [SerializeField]
    private Tile iceTile = null;
    [SerializeField]
    private Tile mountainTile = null;
    [SerializeField]
    private Tile sandTile = null;
    [SerializeField]
    private Tile waterTile = null;

    private void Start()
    {
        GenerateTerrain();
    }

    private void GenerateTerrain()
    {
        
    }
}
