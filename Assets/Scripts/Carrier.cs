using System.Collections.Generic;
using UnityEngine;

public class Carrier : MonoBehaviour
{
    [SerializeField]
    private Transform storage = null;

    private List<Transform> cubeStore = new List<Transform>();

    public void CarryCube(Transform cube)
    {
        cubeStore.Add(cube);
        cube.parent = storage;
    }

    public Transform DropCube()
    {
        if (HasCube())
        {
            Transform cube = cubeStore[0];
            cubeStore.RemoveAt(0);

            return cube;
        }

        return null;
    }

    public bool HasCube()
    {
        return cubeStore.Count > 0;
    }
}
