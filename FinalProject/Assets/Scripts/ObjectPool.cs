using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public GameObject prefab;

    private Queue<GameObject> pool;
    // Start is called before the first frame update
    void Awake()
    {
        pool = new Queue<GameObject>(); //Create pool at beginning
        growPoolSize(); //Get the objs
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
            growPoolSize();
        }

        var nextObj = pool.Dequeue();
        nextObj.SetActive(true);
        return nextObj;
    }

    //
    public void returnToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    //Add to pool size when needed
    private void growPoolSize()
    {
        // Create obj and set it in queue
        for (int i = 0; i < 10; i++)
        {
            var newObj = Instantiate(prefab);
            newObj.SetActive(false);
            pool.Enqueue(newObj);
        }
    }
}
