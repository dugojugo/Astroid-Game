using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    GameObject[] list;
    [SerializeField]
    GameObject[] prefabrock=new GameObject[3];
   
    const int SpawnBorderSize = 10;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;
    Timer spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        // save spawn boundaries for efficiency
        minSpawnX = SpawnBorderSize;
       maxSpawnX = Screen.width - SpawnBorderSize;
      minSpawnY = SpawnBorderSize;
       maxSpawnY = Screen.height - SpawnBorderSize;

        // create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 1;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        
        list = GameObject.FindGameObjectsWithTag("Rock");
        int number = list.Length;
        
        //take random number
       
        // check for time to spawn a new teddy bear
        if (spawnTimer.Finished)
        {
           
            if (number < 5)
            {
                SpawnRock();
                // change spawn timer duration and restart
                spawnTimer.Duration = 1;
                spawnTimer.Run();
            }
        }
     }

    void SpawnRock()
    {
        int choose = Random.Range(0, 3);
        int[] Xplace = { 0, minSpawnX, maxSpawnX };
        int[] Yplace = {0, minSpawnY, maxSpawnY};
        // generate random location and create new rock
        Vector3 location = new Vector3(Xplace[(int)Random.Range(0,3)],
            Yplace[(int)Random.Range(0,3)],
            -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject greenrock = Instantiate(prefabrock[Random.Range(0, 3)]) as GameObject;
        greenrock.transform.position = worldLocation;
    }
    
}
