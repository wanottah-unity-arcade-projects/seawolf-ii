
using UnityEngine;

//
// Sea Wolf v2021.02.03
//
// 2021.01.24
//

public class TopLeftShipSpawner : MonoBehaviour
{
    public static TopLeftShipSpawner spawner;

    public Transform[] ship;

    private float delayTimer;

    private float spawnTimer;

    [HideInInspector] public int randomShip;


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
        delayTimer = 3f;
    }


    private void RunSpawnTimer()
    {
        if (GameController.gameController.topLeftShipActive || GameController.gameController.topRightShipActive)
        {
            return;
        }

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnShip();

            spawnTimer = delayTimer;
        }
    }


    private void SpawnShip()
    {
        randomShip = Random.Range(0, ship.Length);

        ship[randomShip].position = transform.position;

        ship[randomShip].gameObject.SetActive(true);

        GameController.gameController.topLeftShipActive = true;
    }


} // end of class
