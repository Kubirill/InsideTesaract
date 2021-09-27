using UnityEngine;
using System.Collections.Generic;
public class MainCamera : MonoBehaviour {

    
    List<Portal> portals= new List<Portal>();


    void Awake () {
        var trash = FindObjectsOfType<Portal>();
        
        foreach (var tr in trash)
        {
            portals.Add(tr);
        }
    }
    public void AddPortal(Portal newPortal)
    {
        portals.Add(newPortal);
    }


    void OnPreCull () {

        for (int i = 0; i < portals.Count; i++) {
            portals[i].PrePortalRender ();
        }
        for (int i = 0; i < portals.Count; i++) {
            portals[i].Render ();
        }

        for (int i = 0; i < portals.Count; i++) {
            portals[i].PostPortalRender ();
        }

    }

}