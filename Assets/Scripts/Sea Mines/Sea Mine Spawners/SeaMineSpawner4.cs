
using UnityEngine;

//
// Sea Wolf v2021.02.03
//
// 2021.01.24
//

public class SeaMineSpawner4 : MonoBehaviour
{
    public static SeaMineSpawner4 spawner;

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
        Initialise();
    }


    void Update()
    {
        RunSpawnTimer();
    }


    private void Initialise()
    {
        launchTimer = Random.Range(7f, 8f);

        delayTimer = Random.Range(18f, 22f);
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
