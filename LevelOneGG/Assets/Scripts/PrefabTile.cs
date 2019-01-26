﻿using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class PrefabTile : UnityEngine.Tilemaps.TileBase
{
    public Sprite Sprite; //The sprite of tile in the palette
    public GameObject Prefab; //The gameobject to spawn

    private GameObject m_gameObject;


    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        // Assign variables
        tileData.sprite = Sprite;
        if (Prefab) tileData.gameObject = Prefab;
    }

    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {
        // Streangly the position of gameobject starts at Left Bottom point of cell and not at it center
        // TODO need to add anchor points  (vertical and horisontal (left,centre,right)(top,centre,bottom))
        go.transform.position += new Vector3(100,100,0);
        m_gameObject = go;
        return true;
    }

    public bool TileIsLandmark()
    {
        if (m_gameObject.GetComponentInChildren<Landmark>() != null)
        {
            return false;
        }
        return true;
    }
}