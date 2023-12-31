
using UnityEngine;

//
// Sea Wolf v2021.02.01
//
// 2021.01.24
//

public class Player2Controller : MonoBehaviour
{
    public static Player2Controller player2;

    public Transform periscopeReticle;
    public Transform torpedoLauncher;
    public Transform[] torpedoTarget;
    public Transform[] torpedo;
    public Transform[] ammo;

    [HideInInspector] public Vector3[] torpedoTargetPosition;

    private float periscopeReticleSpeed;

    [HideInInspector] public int torpedoCount;

    private float cooldownTimer;
    private float reloadTimer;

    private bool outOfAmmo;


    private void Awake()
    {
        player2 = this;
    }


    private void Update()
    {
        if (GameController.gameController.canPlay && GameController.gameController.twoPlayer)
        {
            KeyboardController();

            Reload();
        }
    }


    public void Initialise()
    {
        torpedoTargetPosition = new Vector3[torpedo.Length];

        periscopeReticle.position = new Vector2(transform.position.x, periscopeReticle.position.y);

        periscopeReticleSpeed = 2f;

        periscopeReticle.gameObject.SetActive(true);

        torpedoCount = 4;

        ReloadAmmo(true);

        reloadTimer = 4f;

        outOfAmmo = false;
    }


    private void KeyboardController()
    {
        float h = Input.GetAxisRaw("Player 2");

        Vector3 newPosition = new Vector3(h, 0, 0);

        newPosition = newPosition.normalized * periscopeReticleSpeed * Time.deltaTime;

        periscopeReticle.position += newPosition;

        if (periscopeReticle.position.x < -1.6f)
        {
            periscopeReticle.position = new Vector3(-1.6f, periscopeReticle.position.y, 0);
        }

        if (periscopeReticle.position.x > 1.6f)
        {
            periscopeReticle.position = new Vector3(1.6f, periscopeReticle.position.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            LaunchTorpedo();
        }
    }


    private void LaunchTorpedo()
    {
        torpedoCount -= 1;

        if (torpedoCount >= 0)
        {
            torpedoTargetPosition[torpedoCount] = periscopeReticle.position;

            torpedoTarget[torpedoCount].gameObject.SetActive(true);

            ammo[torpedoCount].gameObject.SetActive(false);

            torpedo[torpedoCount].position = torpedoLauncher.position;

            torpedo[torpedoCount].gameObject.SetActive(true);
        }

        if (torpedoCount - 1 < 0)
        {
            outOfAmmo = true;

            return;
        }
    }


    private void Reload()
    {
        if (outOfAmmo)
        {
            reloadTimer -= Time.deltaTime;

            if (reloadTimer <= 0)
            {
                torpedoCount = 4;

                ReloadAmmo(true);

                reloadTimer = 4f;

                outOfAmmo = false;
            }
        }
    }


    public void ReloadAmmo(bool reload)
    {
        for (int i = 0; i < ammo.Length; i++)
        {
            ammo[i].gameObject.SetActive(reload);
        }
    }


} // end of class
