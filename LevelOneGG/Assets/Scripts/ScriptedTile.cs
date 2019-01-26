using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScriptedTile : Tile
{
    public enum TileContentType
    {
        Landmark,
        Wall,
        Pickup,
        Hazard,
        Nothing
    }

    //protected const ContentType m_contentType = ContentType.Nothing;

    public TileContentType ContentType;

    public bool TileVisited = false;
    public TileContent m_content;


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
