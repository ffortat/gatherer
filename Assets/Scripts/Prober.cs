using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Prober : MonoBehaviour
{
    private UnityEvent<Tile> onTileTrigger = new UnityEvent<Tile>();

    private void OnCollisionStay(Collision collision)
    {
        Tile tile = collision.collider.GetComponent<Tile>();

        if (tile)
        {
            onTileTrigger.Invoke(tile);
        }
    }

    public void AddTileListener(UnityAction<Tile> callback)
    {
        onTileTrigger.AddListener(callback);
    }
}
