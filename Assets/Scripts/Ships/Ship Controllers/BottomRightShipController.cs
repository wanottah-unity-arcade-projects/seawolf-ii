
using UnityEngine;

//
// Sea Wolf v2021.02.03
//
// 2021.01.24
//

public class BottomRightShipController : MonoBehaviour
{
    public float shipSpeed;

    public int shipPoints;


    void Update()
    {
        Vector3 enemyShip = transform.position;
        
        enemyShip.x -= shipSpeed * Time.deltaTime;

        transform.position = enemyShip;

        if (transform.position.x < -2.5f)
        {
            DestroyShip();
        }
    }


    private void DestroyShip()
    {
        gameObject.SetActive(false);

        GameController.gameController.bottomRightShipActive = false;
    }


    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.collider.CompareTag("Player 1 Torpedo"))
        {
            DestroyShip();

            GameController.gameController.UpdatePlayer1Score(shipPoints);
        }

        if (target.collider.CompareTag("Player 2 Torpedo"))
        {
            DestroyShip();

            GameController.gameController.UpdatePlayer2Score(shipPoints);
        }
    }


} // end of class
