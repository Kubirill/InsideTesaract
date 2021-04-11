using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBeamSize : MonoBehaviour
{
    // Start is called before the first frame update
    public BeamSize[] beams;
    [Range(0.0f, 10.0f)]
    public float beamScale = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beams[0].beamScale != beamScale)
        {
            foreach (BeamSize beam in beams) 
            {
                beam.beamScale = beamScale;
            }
        }
    }
}
