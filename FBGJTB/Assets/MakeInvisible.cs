using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MakeInvisible : MonoBehaviour
{
    private Renderer renderer;
    private Material originalMat;
    [SerializeField] private Material invisibleMat;
    
    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMat = renderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        TurnInvisible(true);
    }


    void TurnInvisible(bool invisibilize)
    {
        if (invisibilize)
            renderer.material = invisibleMat;
        else
            renderer.material = originalMat;
    }
}
