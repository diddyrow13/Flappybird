using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    /*
     * 
     * https://stackoverflow.com/questions/25671746/coroutines-unity
     * used as ref for coroutines
     * Needed since perf degraded significantly after 30ish tubes spawned
     */

    public ObjectPool pool;
    public float spawnTime; // Time in seconds between spawns
    public float bonusMin, bonusMax;
    public float xPos, zPos;

    //public ObjectPool scoreTrigPool;


    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.gameOver.AddListener(onDeath); // sub to death event
        xPos = 30f;
        StartCoroutine(SpawnAsync());
    }

    private IEnumerator SpawnAsync()
    {
        //Waits then spawns tunnels
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            var bonusObj = pool.getFromPool(); //Grab obj from pool

            var yPos = Random.Range(bonusMin, bonusMax); //Random the height for spawn

            bonusObj.transform.position = new Vector3(xPos, yPos, zPos); // Spawn
        }
    }

    private void onDeath()
    {
        StopAllCoroutines(); // prevents spawn of tubes
    }
}
