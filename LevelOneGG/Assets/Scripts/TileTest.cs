using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTest : Tile
{

    public bool TileVisited = false;
    [SerializeField] private TileContent m_content;


    public bool IsTileWalkable()
    {
        switch (m_content.ContentType)
        {
            case TileContent.TileContentType.Landmark:
                return false;

            case TileContent.TileContentType.Pickup:
                return true;

            case TileContent.TileContentType.Wall:
                return false;

            case TileContent.TileContentType.Hazard:
                return true;

            case TileContent.TileContentType.Nothing:
                return true;

            default:
                Debug.LogError("Unhandled Tilecontent");
                return false;
        }
    }

    public TileContent OnTileEntered()
    {
        TileVisited = true;
        return m_content;
    }

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        base.RefreshTile(position, tilemap);
    }
}
