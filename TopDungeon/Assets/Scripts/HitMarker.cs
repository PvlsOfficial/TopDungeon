using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarker : MonoBehaviour
{
    private SpriteRenderer sr;
    private Material defaultMaterial;
    private Material hitMaterial;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultMaterial = sr.material;
        hitMaterial = Resources.Load("Materials/HitMaterial", typeof(Material)) as Material;
    }
    public void Hitmarker()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //make the sprite glow for a second and then return to normal
        sr.material = hitMaterial;
        Invoke("ResetMaterial", 0.1f);
    }

    public void ResetMaterial()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.material = defaultMaterial;
    }
}