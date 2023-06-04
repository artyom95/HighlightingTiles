using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    [SerializeField]
    private Vector2Int _size;

    public Vector2Int Size => _size;

    private Tile[,] _tiles;
    // Start is called before the first frame update
    void Start()
    {
        _tiles = new Tile[_size.x, _size.y];
    }

    public bool IsAvalliablePlace(Vector2Int index)
    {
        var isUnreachablePlace =
            index.x < 0 || index.y < 0 || index.x >= _tiles.GetLength(0) || index.y >= _tiles.GetLength(1);

        if (isUnreachablePlace)
        {
            return false;
        }
        var isFreedomPlaceInArray = _tiles[index.x, index.y] == null;
        return isFreedomPlaceInArray;
    }

    public void SetTile(Vector2Int index, Tile tile)
    {
        _tiles [index.x, index.y] = tile;
    }
    
}
