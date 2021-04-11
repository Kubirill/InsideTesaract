using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesaracatBeamSize : MonoBehaviour
{
    // Start is called before the first frame update
    public CubeBeamSize[] cubes;
    [Range(0.0f, 10.0f)]
    public float beamScale = 1;
    [Range(0.2f, 1000.0f)]
    public float scale = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cubes[0].beamScale != beamScale)
        {
            foreach (CubeBeamSize cube in cubes)
            {
                cube.beamScale = beamScale;
            }
        }
        if (transform.localScale.y != scale)
        {
            transform.localScale = new Vector3(scale, scale, scale);

        }
    }
}
