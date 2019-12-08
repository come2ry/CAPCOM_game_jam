using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public sealed class DestroyObjectWhenOut : MonoBehaviour
{
    Renderer _renderer;
    void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
    }
    void Update()
    {
        if (!_renderer.isVisible) {
            Destroy(gameObject);
        }
    }
}
