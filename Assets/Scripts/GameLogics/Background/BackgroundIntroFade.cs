﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundIntroFade : MonoBehaviour
{
    Material material;
    [Range(0, 1)]
    public float colorAlpha;
    Color c;

    public bool alphaUpdate;
    public MeshRenderer meshR;
    private void Awake()
    {
        meshR.enabled = true;
        material = meshR.material;
        c = material.color;
    }

    void Update()
    {
        if (alphaUpdate)
            material.color = new Color(c.r, c.g, c.b, colorAlpha);
    }

    public void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}
