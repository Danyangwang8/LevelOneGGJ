using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseTileData : MonoBehaviour
{
    [SerializeField] private BoxCollider2D m_collider;
    [SerializeField] private GameObject m_wallObject;
    [SerializeField] private GameObject m_pickupObject;

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

    public void Start()
    {
        m_collider.isTrigger = true;
        ResetTileData();
        AddSelfToManager();
    }

    private void AddSelfToManager()
    {
        GameManager.instance.TileManager.AddTileToManager(this);
    }

    public bool IsTileWalkable()
    {
        switch (ContentType)
        {
            case TileContentType.Landmark:
                return false;

            case TileContentType.Pickup:
                return true;

            case TileContentType.Wall:
                return false;

            case TileContentType.Hazard:
                return true;

            case TileContentType.Nothing:
                return true;

            default:
                Debug.LogError("Unhandled Tilecontent");
                return false;
        }
    }

    public void VisitTile()
    {
        if (TileVisited)
        {
            return;
        }
        TileVisited = true;
        Debug.Log("Tile visited");
    }

    public bool AddWall()
    {
        if (IsTileWalkable() &&
            !TileVisited)
        {
            m_wallObject.SetActive(true);
            return true;
        }

        return false;
    }

    public void ResetTileData()
    {
        TileVisited = false;
        m_wallObject.SetActive(false);
        //m_pickupObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by something?");
        if (other.gameObject.GetComponent<CharacterController>() != null)
        Debug.Log("entered");
        VisitTile();
    }
}
