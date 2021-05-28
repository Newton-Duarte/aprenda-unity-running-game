using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour
{
    private Renderer meshRenderer;
    private Material currentMaterial;

    public string sortingLayer;
    public int orderInLayer;

    public float offsetIncrement;
    public float speed;

    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        currentMaterial = meshRenderer.material;

        meshRenderer.sortingLayerName = sortingLayer;
        meshRenderer.sortingOrder = orderInLayer;
    }

    void FixedUpdate()
    {
        offset += offsetIncrement;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
