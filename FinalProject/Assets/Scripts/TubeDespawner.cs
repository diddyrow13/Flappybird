using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeDespawner : MonoBehaviour
{
    /*
     * POINT OF SCRIPT
     * ---------------------
     * Despawns an object and returns it to the correct pool
     * can despawn: Tubes prefab (2 tubes and score trigger) and bonus sphere
     * 
     */

    public ObjectPool pool;


    private void OnTriggerEnter(Collider other)
    {
        //pool.returnToPool(other.gameObject);
        Destroy(other.gameObject);
    }
}
