
using UnityEngine;

//
// Sea Wolf v2021.01.30
//
// 2021.01.24
//

public class SeaMineSpawner3 : MonoBehaviour
{
    public static SeaMineSpawner3 spawner;

    public Transform[] seaMine;

    private float launchTimer;

    private float delayTimer;

    private float spawnTimer;

    [HideInInspector] public int seaMineCount;


    private void Awake()
    {
        spawner = this;
    }


    private void Start()
    {
        launchTimer = Random.Range(5f, 6f);

        delayTimer = Random.Range(18f, 22f);
    }


    void Update()
    {
        RunSpawnTimer();
    }


    private void RunSpawnTimer()
    {
        launchTimer -= Time.deltaTime;

        if (launchTimer <= 0)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                SpawnSeaMine();

                spawnTimer = delayTimer;
            }
        }
    }


    private void SpawnSeaMine()
    {
        if (seaMineCount >= seaMine.Length - 1)
        {
            seaMineCount = -1;
        }

        else
        {
            seaMineCount += 1;

            seaMine[seaMineCount].position = transform.position;

            seaMine[seaMineCount].gameObject.SetActive(true);
        }
    }


} // end of class
