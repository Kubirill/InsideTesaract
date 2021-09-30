using UnityEngine;
using System.Collections.Generic;
public class MainCamera : MonoBehaviour {

    
    public List<Portal> portals= new List<Portal>();
    bool active = false;

    void Start () {
        if (gameObject == GameObject.FindGameObjectWithTag("MainCamera"))
           {
            var trash = FindObjectsOfType<Portal>();

            foreach (var tr in trash)
            {

                //portals.Add(tr);
            }
        }
        
    }
    public void AddPortal(Portal newPortal)
    {
        portals.Add(newPortal);
    }
    public bool ContainPortal(Portal newPortal)
    {
        return portals.Contains(newPortal);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            active = true;
        }
    }

    void OnPreCull () {
        if (active)
        {
            for (int i = 0; i < portals.Count; i++)
            {
                portals[i].PrePortalRender();
            }
            for (int i = 0; i < portals.Count; i++)
            {
                portals[i].Render();
            }

            for (int i = 0; i < portals.Count; i++)
            {
                portals[i].PostPortalRender();
            }
        }
        

    }

}