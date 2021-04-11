using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesaracatBeamSize : MonoBehaviour
{
    // Start is called before the first frame update
    public CubeBeamSize[] cubes;
    [Range(0.0f, 10.0f)]
    public float beamScale = 1;
    public float speedBeamScale = 0.1f;
    [Range(0.2f, 1000.0f)]
    public float scale = 1;
    public float speedScale = 0.1f;
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
        ControllCheck();
    }

    public void ChangeSize(float value)
    {
        scale = Mathf.Clamp(scale + value* scale/10, 0.2f, 1000.0f);
    }
    public void ChangeBeamSize(float value)
    {
        beamScale = Mathf.Clamp(beamScale + value, 0f, 10.0f);
    }
    
    public void ControllCheck()
    {
        if (Input.GetKey(KeyCode.Alpha1)) 
            {
                ChangeSize(-speedScale);
            }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            ChangeSize(speedScale);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ChangeBeamSize(-speedBeamScale);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            ChangeBeamSize(speedBeamScale);
        }
    }
}
