using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GameController : MonoBehaviour
{
    /// <summary>
    /// Данный метод вызывается автоматически при клике на кнопки с изображениями тайлов.
    /// В качестве параметра передается префаб тайла, изображенный на кнопке.
    /// Вы можете использовать префаб tilePrefab внутри данного метода.
    /// </summary>

   
    [SerializeField] 
    private Map _map;

    [SerializeField] 
    private MapIndexProvider _mapIndexProvider;

    private Camera _camera;
    private Tile _currentTile;

    private void Awake()
    {
        _camera = Camera.main;
    }

    [UsedImplicitly]
    public void StartPlacingTile(GameObject tilePrefab)
    {
        var tileObject = Instantiate(tilePrefab);
        _currentTile = tileObject.GetComponent<Tile>();
        _currentTile.gameObject.transform.SetParent(_map.transform);
        
    }

    private void Update()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo)&& _currentTile !=null)
        {
            var tileIndex = _mapIndexProvider.GetIndex(hitInfo.point);
            var tilePosition = _mapIndexProvider.GetPosition(tileIndex);
            _currentTile.gameObject.transform.localPosition = tilePosition;

            var avaliable = _map.IsAvalliablePlace(tileIndex);
            _currentTile.Recoloring(avaliable);
            
            if (!avaliable)
            {
               return;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                _map.SetTile(tileIndex, _currentTile);
                _currentTile.ResetColor();
                _currentTile = null;
            }
        }
    }
}
