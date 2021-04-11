using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesaractControllObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] objects;
    [Range(0.0f, 1.0f)]
    public float objectsScale = 1;
    public float objectSpeed=0.1f;
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
        ControllCheck();
    }
    public void ChangeObjectsSize(float value)
    {
        objectsScale = Mathf.Clamp(objectsScale + value, 0.0f, 1.0f);
    }
    public void ChangeActiveObject()
    {
        objectsActive = !objectsActive;
    }
    public void ControllCheck()
    {
        if (Input.GetKey(KeyCode.Alpha5))
        {
            ChangeObjectsSize(-objectSpeed);
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            ChangeObjectsSize(objectSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ChangeActiveObject();
        }
    }
}
