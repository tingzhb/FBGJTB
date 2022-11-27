using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResizePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine (ChangeSize ());
    }

    public IEnumerator ChangeSize()
    {
        float randomX = Random.Range(-10, 3);
        float randomY = Random.Range(-10, 2);
        float randomZ = Random.Range(-10, 4);
        Vector3 originalLocalScale = transform.localScale;
        transform.localScale = new Vector3(randomX, randomY, randomZ);
        yield return new WaitForSeconds(15f);
        transform.localScale = originalLocalScale;
    }
    
}
