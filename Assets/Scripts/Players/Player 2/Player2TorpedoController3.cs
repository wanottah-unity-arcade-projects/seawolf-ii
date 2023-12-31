
using UnityEngine;

//
// Sea Wolf v2021.02.03
//
// 2021.01.24
//

public class Player2TorpedoController3 : MonoBehaviour
{
    public float torpedoSpeed;

    private const int TORPEDO_3 = 2;


    void Update()
    {
        MoveTorpedo();
    }


    private void MoveTorpedo()
    {
        Vector3 direction = (Player2Controller.player2.torpedoTargetPosition[TORPEDO_3] - transform.position).normalized;

        transform.position += direction * torpedoSpeed * Time.deltaTime;

        if (Vector3.Distance(Player2Controller.player2.torpedoTargetPosition[TORPEDO_3], transform.position) <= 0.1f)
        {
            gameObject.SetActive(false);

            Player2Controller.player2.torpedoTarget[TORPEDO_3].gameObject.SetActive(false);
        }
    }


    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.collider.CompareTag("Player 1 Torpedo"))
        {
            gameObject.SetActive(false);
        }

        if (target.collider.CompareTag("Sea Mine"))
        {
            gameObject.SetActive(false);
        }

        if (target.collider.CompareTag("Aircraft Carrier"))
        {
            gameObject.SetActive(false);
        }

        if (target.collider.CompareTag("Battle Ship"))
        {
            gameObject.SetActive(false);
        }

        if (target.collider.CompareTag("Cruiser"))
        {
            gameObject.SetActive(false);
        }

        if (target.collider.CompareTag("Destroyer"))
        {
            gameObject.SetActive(false);
        }

        if (target.collider.CompareTag("Fast Torpedo Boat"))
        {
            gameObject.SetActive(false);
        }

        if (target.collider.CompareTag("Submarine"))
        {
            gameObject.SetActive(false);
        }

        if (target.collider.CompareTag("Frigate"))
        {
            gameObject.SetActive(false);
        }

        Player2Controller.player2.torpedoTarget[TORPEDO_3].gameObject.SetActive(false);
    }


} // end of class
