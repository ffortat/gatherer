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
        cube.GetComponent<Rigidbody>().detectCollisions = false;
        cube.GetComponent<Rigidbody>().isKinematic = true;
        cube.localPosition = Vector3.zero;
    }

    public Transform DropCube()
    {
        if (HasCube())
        {
            Transform cube = cubeStore[0];
            cubeStore.RemoveAt(0);

            cube.GetComponent<Rigidbody>().detectCollisions = true;
            cube.GetComponent<Rigidbody>().isKinematic = false;

            return cube;
        }

        return null;
    }

    public bool HasCube()
    {
        return cubeStore.Count > 0;
    }
}
