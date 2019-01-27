using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    //public ITilemap m_baseTileMap;
    [SerializeField] private Tilemap m_baseTileMap;
    [SerializeField] private Tilemap m_landmarkTileMap;
    [SerializeField] private CharacterController m_character;

    private Transform m_characterTransform;
    private TileData m_activeTile;
    private List<BaseTileData> m_tiles = new List<BaseTileData>();
    
    public bool Initialized = false;

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
        m_baseTileMap.CompressBounds();
        m_landmarkTileMap.CompressBounds();
    }

    public void Initialize()
    {
        Initialized = true;

        ShowUpItems();
        int countUnblockedTiles = 0;
        int countBlockedTiles = 0;
        foreach (var pos in m_baseTileMap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = m_baseTileMap.CellToWorld(localPlace);
            if (m_baseTileMap.HasTile(localPlace))
            {
                Debug.Log("Base tile found at:" + localPlace);
                BaseTileData tileData = GetBaseTileData(localPlace);
                if (tileData != null)
                {
                    AddTileToManager(tileData);
                }
                //AddTileToManager(GetBaseTileData(localPlace));
                if (m_landmarkTileMap.HasTile(localPlace))
                {
                    countBlockedTiles++;
                    Debug.Log(localPlace + " contains a landmark");
                    Tiles[Tiles.Count - 1].SetBlockedByLandmark();
                }
                else
                {
                    countUnblockedTiles++;
                    Tiles[Tiles.Count - 1].SetNotBlockedByLandmark();
                    Debug.Log(localPlace + " does NOT contain a landmark");

                }

                Debug.Log("Blocked tiles: " + countBlockedTiles + ", Unblocked tiles: " + countUnblockedTiles);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3Int currentPosition = new Vector3Int((int)m_characterTransform.position.x, (int)m_characterTransform.position.y, (int)m_characterTransform.position.z);
        //BaseTileData activeTileData = GetBaseTileData(currentPosition);
        //activeTileData.VisitTile();

        if (Input.GetButton("Test"))
        {
            ActivateMaze();
        }
    }

    public void ShowUpItems()
    {
        foreach(BaseTileData tile in m_tiles)
        {
            if (!tile.BlockedByLandmark)
            {
                tile.AddPickupableObject();
            }
        }
    }

    public void AddTileToManager(BaseTileData tileData)
    {
        m_tiles.Add(tileData);
    }

    private BaseTileData GetBaseTileData(Vector3Int currentPosition)
    {
        ITilemap tilemap = null;
        TileBase foundTile = m_baseTileMap.GetTile(currentPosition);
        if (foundTile.GetType() == typeof(PrefabTile))
        {
            PrefabTile tile = foundTile as PrefabTile;
            return tile.GetBaseTileObject(currentPosition).GetComponent<BaseTileData>();
        }
        //foundTile.GetTileData(currentPosition, tilemap, ref m_activeTile);
        //return m_activeTile.gameObject.GetComponent<BaseTileData>();
        return null;
    }

    public void ActivateMaze()
    {
        foreach (BaseTileData tileData in m_tiles)
        {
            tileData.AddWall();
        }
    }
}
