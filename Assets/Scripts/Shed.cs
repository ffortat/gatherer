using System.Collections.Generic;
using UnityEngine;

public class Shed : MonoBehaviour
{
    [SerializeField]
    private Transform spawn = null;
    [SerializeField]
    private Transform cubePrefab = null;

    private List<Transform> cubes = new List<Transform>();

    public void SpawnCubes(int count)
    {
        for (int i = 0; i < count; i += 1)
        {
            Transform cube = Instantiate(cubePrefab);
            cube.parent = spawn;
            cube.localPosition = Vector3.zero;
            cubes.Add(cube);
        }
    }

    public Transform TakeCube()
    {
        if (cubes.Count > 0)
        {
            var cube = cubes[0];
            cubes.RemoveAt(0);
            return cube;
        }

        return null;
    }

    public void PutCube(Transform cube)
    {
        if (cube)
        {
            cube.parent = spawn;
            cube.localPosition = Vector3.zero;
            cubes.Add(cube);
        }
    }
}
