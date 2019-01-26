using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileContent : MonoBehaviour
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
}
