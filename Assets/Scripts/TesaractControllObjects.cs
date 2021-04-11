using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesaractControllObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] objects;
    [Range(0.0f, 1.0f)]
    public float objectsScale = 1;
    public bool objectsActive=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objects[0].transform.localScale.x != objectsScale)
        {
            foreach (GameObject obj in objects)
            {
                obj.transform.localScale = Vector3.one* objectsScale;
            }
        }
        if (objects[0].activeSelf != objectsActive)
        {
            foreach (GameObject obj in objects)
            {
                obj.SetActive( objectsActive);
            }
        }
    }
}
