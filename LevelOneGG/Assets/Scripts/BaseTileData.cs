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

    public bool BlockedByLandmark = false;

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
        //AddSelfToManager();
    }

    private void AddSelfToManager()
    {
        GameManager.instance.TileManager.AddTileToManager(this);
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
        if (!BlockedByLandmark &&
            !TileVisited)
        {
            m_wallObject.SetActive(true);
            if (m_pickupObject.gameObject.activeSelf)
            {
                m_pickupObject.gameObject.SetActive(false);
            }
            return true;
        }
        else if (BlockedByLandmark)
        {
            Debug.Log("Tile blocked by landmark");
        }
        return false;
    }

    internal void SetNotBlockedByLandmark()
    {
        BlockedByLandmark = false;
    }

    public void ResetTileData()
    {
        TileVisited = false;
        m_wallObject.SetActive(false);
        //BlockedByLandmark = false;
        //m_pickupObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CharacterController>() != null)
        {
            VisitTile();
        }
    }

    public void AddPickupableObject()
    {
        if (!BlockedByLandmark)
        {
            m_pickupObject.gameObject.SetActive(true);
            m_pickupObject.GetComponent<Pickup>().CreatObjectWithDifSprite();
        }
    }

    public void SetBlockedByLandmark()
    {
        BlockedByLandmark = true;
    }
}
