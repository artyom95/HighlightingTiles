using UnityEngine;
  class GrassHighlighting : HighlightingBehaviour
{
    protected override void Recoloring()
    {
        _renderer.material.color = Color.cyan;
    }
}
