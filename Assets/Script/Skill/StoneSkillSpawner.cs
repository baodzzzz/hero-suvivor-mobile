using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSkillSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabsStone;

    Timer spawnTimer;


    const int SpawnBorderSize = 100;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;
    // Start is called before the first frame update
    void Start()
    {
        /* point = 0;
         pointTxt.text = "Score :" + point.ToString();*/
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 4;
        spawnTimer.Run();
    }
    void SpawnerStone()
    {
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
           Random.Range(minSpawnY, maxSpawnY),
           -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        GameObject circle = Instantiate(prefabsStone, transform.position, Quaternion.identity) as GameObject;
        AudioManager.Play(AudioClipName.SKillRock);
        circle.transform.position = worldLocation;

    }



    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            SpawnerStone();
            spawnTimer.Duration = 4;
            spawnTimer.Run();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Minion"))
        {
            /*point += 1;
            pointTxt.text = "Score :" + point.ToString();*/
            Destroy(gameObject);
        }
    }
}
