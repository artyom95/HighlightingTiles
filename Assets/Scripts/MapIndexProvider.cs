using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIndexProvider : MonoBehaviour
{
    [SerializeField]
    private Map _map;
    // Start is called before the first frame update
    public Vector2Int GetIndex(Vector3 worldPosition)
    {
        var tilePositionInMap = _map.transform.InverseTransformPoint(worldPosition);

        var x = MathF.Floor(tilePositionInMap.x);
        var y = MathF.Floor(tilePositionInMap.z);

        var mapIndex = new Vector2Int((int)x, (int)y) + _map.Size / 2;
        return mapIndex;
    }

    public Vector3 GetPosition(Vector2Int index)
    {
        var halfTileSize = Vector2.one / 2;
        var tilePositionXY = index - _map.Size / 2 + halfTileSize;
        return new Vector3(tilePositionXY.x, 0f, tilePositionXY.y);
    }
}
