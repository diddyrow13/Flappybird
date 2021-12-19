using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTube : MonoBehaviour
{

    /*
     * 
     * https://stackoverflow.com/questions/25671746/coroutines-unity
     * used as ref for coroutines
     * Needed since perf degraded significantly after 30ish tubes spawned
     */

    public ObjectPool pool;
    public float spawnTime; // Time in seconds between spawns
    //public float gapSize; //Depricated when combined tube to tubes
    public float tubeMin, tubeMax;
    public  float xPos, zPos;

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
            yield return new WaitForSeconds(spawnTime); //Stops and waits for timer

            //var topTunnel = pool.getFromPool();
            //var botTunnel = pool.getFromPool();

            var tunnels = pool.getFromPool();

            //var scoreTrig = scoreTrigPool.getFromPool();

            var gapPos = Random.Range(tubeMin, tubeMax);

            tunnels.transform.position = new Vector3(xPos, gapPos, zPos);

            //botTunnel.transform.position = new Vector3(xPos, gapPos - gapSize - botTunnel.transform.localScale.y / 2, zPos);
            //topTunnel.transform.position = new Vector3(xPos, gapPos + gapSize + topTunnel.transform.localScale.y / 2, zPos);
            //scoreTrig.transform.position = new Vector3(xPos, gapPos, zPos);

            //botTunnel.transform.position = new Vector3(xPos, gapPos, zPos);
            //topTunnel.transform.position = new Vector3(xPos, gapPos + gapSize + topTunnel.transform.localScale.y, zPos);
        }
    }

    private void onDeath()
    {
        StopAllCoroutines(); // prevents spawn of tubes
    }
}
