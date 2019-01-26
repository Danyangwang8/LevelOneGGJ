using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    public GameObject[] items;

    public float itemNumber;

    private void Start()
    {
        foreach(BaseTileData tile in GameManager.instance.TileManager.Tiles)
        {
            tile.PickupObject.GetComponent<Rigidbody2D>();
            tile.PickupObject.GetComponent<BoxCollider2D>();
            tile.PickupObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
