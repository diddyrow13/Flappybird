using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTube : MonoBehaviour
{

    private ObjectPool pool;
    public float spawnTime; // Time in seconds between spawns
    public float gapSize;
    public float tubeMin, tubeMax;
    public  float xPos, zPos;

    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<ObjectPool>();
        StartCoroutine(SpawnAsync());
    }

    private IEnumerator SpawnAsync()
    {
        //Waits then spawns tunnels
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            var topTunnel = pool.getFromPool();
            var botTunnel = pool.getFromPool();


            var gapPos = Random.Range(tubeMin, tubeMax);
            botTunnel.transform.position = new Vector3(xPos, gapPos - gapSize - botTunnel.transform.localScale.y / 2, zPos);
            topTunnel.transform.position = new Vector3(xPos, gapPos + gapSize + topTunnel.transform.localScale.y / 2, zPos);

            //botTunnel.transform.position = new Vector3(xPos, gapPos, zPos);
            //topTunnel.transform.position = new Vector3(xPos, gapPos + gapSize + topTunnel.transform.localScale.y, zPos);
        }
    }
}
