using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] 
    private Color _permissiveColor;
    
    [SerializeField] 
    private Color _forbiddenColor;

    private List<Material> _materials = new List<Material>();

    private void Awake()
    {
        var renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var renderer in renderers)
        {
            _materials.Add(renderer.material);
        }
    }

    public void Recoloring(bool permissive)
    {
        if (permissive)
        {
            foreach (var material in _materials)
            {
                material.color = _permissiveColor;
            }
        }
        else
        {
            foreach (var material in _materials)
            {
                material.color = _forbiddenColor;
            } 
        }
    }

    public void ResetColor()
    {
        foreach (var material in _materials)
        {
            material.color = Color.white;
        }
    }
}


