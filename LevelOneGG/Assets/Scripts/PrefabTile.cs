using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class PrefabTile : UnityEngine.Tilemaps.TileBase
{
    public Sprite Sprite; //The sprite of tile in the palette
    public GameObject Prefab; //The gameobject to spawn

    private GameObject m_gameObject;

    private Dictionary<Vector3Int, GameObject> m_baseTileObjects = new Dictionary<Vector3Int, GameObject>();
    private Dictionary<Vector3Int, GameObject> m_landMarkObjects = new Dictionary<Vector3Int, GameObject>();


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
        if (Application.isPlaying)
        {
            go.SetActive(true);
        }
        else
        {
            go.SetActive(false);
        }

        if (go.GetComponent<BaseTileData>())
        {
            if (!m_baseTileObjects.ContainsKey(position))
            {
                m_baseTileObjects.Add(position, go);
            }

            Debug.Log("Current baseTileData object count: " + m_baseTileObjects.Count);
        }
        else if(go.GetComponent<Landmark>())
        {
            if (!m_landMarkObjects.ContainsKey(position))
            {
                m_landMarkObjects.Add(position, go);
            }
            Debug.Log("Current landmark object count: " + m_landMarkObjects.Count);

        }
        go.transform.position += new Vector3(100,100,0);
        m_gameObject = go;
        return true;
    }

    public GameObject GetBaseTileObject(Vector3Int position)
    {
        GameObject returnGO;
        m_baseTileObjects.TryGetValue(position, out returnGO);
        return returnGO;
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