using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    /*
     * 
     * https://stackoverflow.com/questions/24442389/trouble-getting-a-game-object-from-object-pool-in-unity
     * used as ref
     * Needed since perf degraded significantly after 30ish tubes spawned
     */

    public GameObject prefab;   //Has a pool of prefabs for reuse

    private Queue<GameObject> pool; //Using Q for better funcionality vs list

    // Start is called before the first frame update
    void Awake()
    {
        pool = new Queue<GameObject>(); //Create pool at beginning
        growPoolSize(); //Get the objs, since empty
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Returns an object from the pool
    public GameObject getFromPool()
    {
        // Check if pool is empty
        if (pool.Count <= 1)
        {
            growPoolSize(); // Pool empty so grow it
        }

        var nextObj = pool.Dequeue();   // Grab from pool
        nextObj.SetActive(true);        // Make the obj active
        return nextObj;             
    }

    //
    public void returnToPool(GameObject obj)
    {
        obj.SetActive(false);   // Turn object off
        pool.Enqueue(obj);      // Put obj back in pool Q
    }

    //Add to pool size when needed
    private void growPoolSize()
    {
        // Create obj and set it in queue
        for (int i = 0; i < 10; i++)
        {
            var newObj = Instantiate(prefab);   // get ob ready
            newObj.SetActive(false);            // turn it off
            pool.Enqueue(newObj);               // Put it in Q
        }
    }
}
