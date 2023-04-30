using UnityEngine;
 class BridgeHighlighting : HighlightingBehaviour
{
 protected override void Recoloring()
 {
  _renderer.material.color = Color.red;
 }
}
