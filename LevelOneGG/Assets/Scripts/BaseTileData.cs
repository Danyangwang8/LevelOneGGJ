using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseTileData : MonoBehaviour
{
    [SerializeField] private BoxCollider2D m_collider;
    [SerializeField] private GameObject m_wallObject;
    [SerializeField] private Pickup m_pickupObject;

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

    public Pickup PickupObject
    {
        get
        {
            return m_pickupObject;
        }
    }

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
        if (m_pickupObject.gameObject.activeSelf)
        {
            m_pickupObject.PickupObject();
        }
        Debug.Log("Tile visited");
    }

    public bool AddWall()
    {
        if (IsTileWalkable() &&
            !TileVisited)
        {
            m_wallObject.SetActive(true);
            if (m_pickupObject.gameObject.activeSelf)
            {
                m_pickupObject.gameObject.SetActive(false);
            }
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
        VisitTile();
    }

    public void AddPickupableObject()
    {
        m_pickupObject.gameObject.SetActive(true);
    }
}
