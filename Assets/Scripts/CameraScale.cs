using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScale : MonoBehaviour
{
    public Transform insideObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one / insideObj.localScale.x;
        if (Input.GetKeyDown(KeyCode.I))
        {
            LayersCounter.GetNewStep();
            Debug.Log(LayersCounter.GetStep());
        }
    }

}
