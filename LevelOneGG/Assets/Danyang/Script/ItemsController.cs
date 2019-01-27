using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    private Pickup pickup;
    private int R_Num = 10;


    private void Start()
    {
        foreach(BaseTileData tile in GameManager.instance.TileManager.Tiles)
        {
            tile.PickupObject.GetComponent<Rigidbody2D>();
            tile.PickupObject.GetComponent<BoxCollider2D>();
            tile.PickupObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
private void Update()
    {
        CreatePickupObjec();
    }

    void CreatePickupObjec()
    {
        
        for (int i = 0; i < pickup.pickupNums;i++)
        {
            foreach (BaseTileData tile in GameManager.instance.TileManager.Tiles)
            {
                int j = Random.Range(0, 15);
                if(R_Num == j)
                {
                    tile.AddPickupableObject();
                    pickup.CreatObjectWithDifSprite();
                }

            }

        }

    }


}
