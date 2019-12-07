using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOutDestroy : MonoBehaviour
{
    [SerializeField]
    private Renderer _renderer;

    private void Start()
    {
        _renderer = this.transform.GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        if (!_renderer.isVisible)
            Destroy(this.gameObject);
    }
}
