using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeDespawner : MonoBehaviour
{

    private ObjectPool pool;


    private void OnTriggerEnter(Collider other)
    {
        pool.returnToPool(other.gameObject);
    }
}
