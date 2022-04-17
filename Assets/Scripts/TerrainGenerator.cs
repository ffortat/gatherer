using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Forest,
    Grass,
    Ice,
    Mountain,
    Sand,
    Water
}

[ExecuteAlways]
public class TerrainGenerator : SerializedMonoBehaviour
{
    [SerializeField]
    private Dictionary<TileType, Tile> tilesPrefab = new Dictionary<TileType, Tile>();
    [SerializeField]
    private int terrainWidth = 10;
    [SerializeField]
    private int terrainHeight = 10;

    private void Start()
    {
        GenerateTerrain();
    }

    private void GenerateTerrain()
    {
        for (int x = 0; x < terrainWidth; x += 1)
        {
            for (int z = 0; z < terrainHeight; z += 1)
            {
                Tile tile = Instantiate(tilesPrefab[(TileType)Random.Range(0, 6)]);
                tile.transform.parent = transform;
                tile.transform.localPosition = new Vector3(x * 2f + (z % 2), 0, z * 1.75f);
            }
        }

        transform.localPosition = new Vector3(-terrainWidth, -0.5f, -terrainHeight * 1.75f / 2f);
    }
}
