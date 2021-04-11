using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSize : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0.0f,10.0f)]
    public float beamScale=1;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.y != beamScale)
        {
            transform.localScale = new Vector3(transform.localScale.x,beamScale, beamScale);
            
        }
    }
}
