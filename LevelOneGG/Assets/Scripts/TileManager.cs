using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    //public ITilemap m_baseTileMap;
    [SerializeField] private Tilemap m_tileMap;
    [SerializeField] private CharacterController m_character;

    private Transform m_characterTransform;
    private TileData m_activeTile;
    private List<BaseTileData> m_tiles = new List<BaseTileData>();

    public List<BaseTileData> Tiles
    {
        get
        {
            return m_tiles;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_characterTransform = m_character.transform;
        ShowUpItems();
        //foreach (var pos in m_tileMap.cellBounds.allPositionsWithin)
        //{
            //Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            //Vector3 place = m_tileMap.CellToWorld(localPlace);
            //if (m_tileMap.HasTile(localPlace))
            //{
                //AddTileToManager(GetBaseTileData(localPlace));
            //}
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3Int currentPosition = new Vector3Int((int)m_characterTransform.position.x, (int)m_characterTransform.position.y, (int)m_characterTransform.position.z);
        //BaseTileData activeTileData = GetBaseTileData(currentPosition);
        //activeTileData.VisitTile();

        if (Input.GetButton("Test"))
        {
            foreach (BaseTileData tileData in m_tiles)
            {
                tileData.AddWall();
            }
        }
    }

    public void ShowUpItems()
    {
        foreach(BaseTileData tile in m_tiles)
        {
            if (true)
            {
                tile.AddPickupableObject();
            }
        }
    }

    public void AddTileToManager(BaseTileData tileData)
    {
        m_tiles.Add(tileData);
    }
}
