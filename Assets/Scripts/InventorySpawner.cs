using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySpawner : MonoBehaviour
{
    public static InventorySpawner instance;
    public UIInventory invPrefab;

    private void Awake()
    {
        instance = this;
    }
    public void SpawnInventory()
    {
        UIInventory newInv = Instantiate(invPrefab);
        newInv.transform.SetParent(transform, false);
        newInv.transform.position = Input.mousePosition;
    }
}
