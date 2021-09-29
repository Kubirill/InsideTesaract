using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayTesaract : MonoBehaviour
{
    public int depth;
    public MainCamera mainCam;
    public List<Portal> portalsClone;
    //public List<Portal> portalsCloneSecond;
    Camera mainPortalCam;
    public float step=1000;
    // Start is called before the first frame update
    public void Awake()
    {
        
    }
    void Start()
    {
        CloneSelf();
        //LayersCounter.depth = depth;
    }

    public void CloneSelf()
    {
        if (depth > 0)
        {
            var trashes = GetComponentsInChildren<Portal>();
            foreach (var trash in trashes)
            {
                if (!trash.main)
                {
                    portalsClone.Add(trash);
                    
                }
                else
                {
                   // mainPortalCam = trash.portalCam;
                }

            }
            foreach (var portal in portalsClone)
            {
                var newForm = Instantiate(gameObject, transform.position + Vector3.right * depth * step * LayersCounter.GetNewLayer(), Quaternion.identity);
                newForm.GetComponent<MultiplayTesaract>().depth = depth - 1;
                newForm.name = portal.name + "_"+ newForm.name;
                newForm.GetComponent<MultiplayTesaract>().CloneSelf();
                var subPortals = newForm.GetComponentsInChildren<Portal>();

                
                

                foreach (var subPortal in subPortals)
                {
                    
                    if (subPortal.portalName == portal.linkPortalName)
                    {

                        portal.linkedPortal = subPortal;
                        subPortal.linkedPortal = portal;
                        subPortal.StartPortalRender();
                        portal.StartPortalRender();
                        subPortal.main = true;
                        
                    }
                    
                }
                foreach (var subPortal in subPortals)
                {

                    if (subPortal.portalName != portal.linkPortalName) subPortal.playerCam = portal.linkedPortal.portalCam;
                    if (subPortal.playerCam.GetComponent<MainCamera>() == null)
                    {
                        subPortal.playerCam.gameObject.AddComponent<MainCamera>();
                    }

                    if (!subPortal.playerCam.GetComponent<MainCamera>().ContainPortal(subPortal))
                    {
                        Debug.Log("Add in main Camer" + subPortal + subPortal.transform.parent + " " + subPortal.playerCam.transform.parent);
                        subPortal.playerCam.GetComponent<MainCamera>().AddPortal(subPortal);
                    }
                    
                    if (subPortal.portalName != portal.linkPortalName)
                    {
                        Debug.Log(subPortal.playerCam +" "+ portal.linkedPortal.portalCam);
                        
                        Debug.Log(subPortal.playerCam);
                        foreach (var subPortal2 in subPortals)
                        {
                            if ((subPortal.portalName == subPortal2.linkPortalName)&& (subPortal2.portalName != portal.linkPortalName))
                            {

                                subPortal2.linkedPortal = subPortal;
                                subPortal.linkedPortal = subPortal2;
                                subPortal.StartPortalRender();
                                subPortal2.StartPortalRender();
                                subPortal.main = true;
                                continue;
                            }
                        }
                    }
                    
                }

                // cam.GetComponent<Camera>().cullingMask = 1 << LayersCounter.GetNewLayer();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
