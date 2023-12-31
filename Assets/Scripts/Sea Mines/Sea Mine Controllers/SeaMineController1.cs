
using UnityEngine;

//
// Sea Wolf v2021.02.03
//
// 2021.01.24
//

public class SeaMineController1 : MonoBehaviour
{
    private float seaMineSpeed;


    private void Start()
    {
        Initialise();
    }


    void Update()
    {
        MoveSeaMine();
    }


    private void Initialise()
    {
        seaMineSpeed = Random.Range(0.03f, 0.06f);
    }


    private void MoveSeaMine()
    {
        Vector3 seaMine = transform.position;

        seaMine.x += seaMineSpeed * Time.deltaTime;

        transform.position = seaMine;

        if (transform.position.x > 1.9f)
        {
            DestroySeaMine();
        }
    }


    private void DestroySeaMine()
    {
        gameObject.SetActive(false);
    }


    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.collider.CompareTag("Sea Mine"))
        {
            DestroySeaMine();
        }

        if (target.collider.CompareTag("Player 1 Torpedo"))
        {
            DestroySeaMine();
        }

        if (target.collider.CompareTag("Player 2 Torpedo"))
        {
            DestroySeaMine();
        }
    }


} // end of class
