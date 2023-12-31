
using UnityEngine;

//
// Sea Wolf v2021.02.03
//
// 2021.01.24
//

public class Waves : MonoBehaviour
{
    private Renderer wave;

    public float waveSpeed;

    private Vector2 waveOffset;


    private void Awake()
    {
        wave = GetComponent<Renderer>();
    }


    private void Update()
    {
        waveOffset = new Vector2(Time.time * waveSpeed, 0f);

        wave.material.mainTextureOffset = waveOffset;
    }


} // end of class
