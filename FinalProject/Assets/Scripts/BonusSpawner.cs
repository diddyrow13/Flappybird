using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    /*
     * 
     * https://stackoverflow.com/questions/25671746/coroutines-unity
     * used as ref for coroutines
     *
     * POINT OF SCRIPT
     * ---------------------
     * Spawns a bonus sphere that gives the player a +5
     * Stops the sphere(s) on game over
     * 
     */

    public ObjectPool pool;
    public float spawnTime; // Time in seconds between spawns
    public float bonusMin, bonusMax;
    public float xPos, zPos;
    public float spawnChance;



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

            // Get the spawn chance
            var randNum = Random.Range(1, 100);

            if (randNum < spawnChance)
            {
                var bonusObj = pool.getFromPool(); //Grab obj from pool

                var yPos = Random.Range(bonusMin, bonusMax); //Random the height for spawn

                bonusObj.transform.position = new Vector3(xPos, yPos, zPos); // Spawn
            }
            else
                continue;

            //var bonusObj = pool.getFromPool(); //Grab obj from pool

            //var yPos = Random.Range(bonusMin, bonusMax); //Random the height for spawn

            //bonusObj.transform.position = new Vector3(xPos, yPos, zPos); // Spawn
        }
    }

    // bonus' will continue to spawn unless this function is active
    private void onDeath()
    {
        StopAllCoroutines(); // prevents spawn of tubes
    }
}
