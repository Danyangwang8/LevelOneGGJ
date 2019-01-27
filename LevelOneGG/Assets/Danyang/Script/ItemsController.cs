using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    private int R_Num = 10;

    public bool pickupsCreated = false;



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
        if (!pickupsCreated)
        CreatePickupObjec();
    }

    void CreatePickupObjec()
    {
        pickupsCreated = true;
            foreach (BaseTileData tile in GameManager.instance.TileManager.Tiles)
            {
                int j = Random.Range(0, 15);
                if(R_Num == j)
                {
                    tile.AddPickupableObject();
                    
                }

            }

    }


}
