using UnityEngine;

  abstract class HighlightingBehaviour : MonoBehaviour
{
    [SerializeField] 
    private Collider _collider;
    [SerializeField] 
    protected Renderer _renderer;

    protected Color _currentColor;
    // Update is called once per frame
    private void Start()
    {
        _currentColor = _renderer.material.color;
    }
    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (_collider.Raycast(ray, out var hitInfo, 100f))
        {
            Recoloring();
        }
        else
        {
            _renderer.material.color = _currentColor;
        }
    }
    protected abstract void Recoloring();
}