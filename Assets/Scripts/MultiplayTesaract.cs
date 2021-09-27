using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayTesaract : MonoBehaviour
{
    public int depth;

    public List<Portal> portalsClone;

    public float step=1000;
    // Start is called before the first frame update
    public void Awake()
    {
        
    }
    void Start()
    {
        CloneSelf();
    }

    public void CloneSelf()
    {
        if (depth > 0)
        {
            var treshes = GetComponentsInChildren<Portal>();
            foreach (var tresh in treshes)
            {
                portalsClone.Add(tresh);

            }
            foreach (var portal in portalsClone)
            {
                var newForm = Instantiate(gameObject, transform.position + Vector3.right * depth * step * LayersCounter.GetNewLayer(), Quaternion.identity);
                newForm.GetComponent<MultiplayTesaract>().depth = depth - 1;
                newForm.GetComponent<MultiplayTesaract>().CloneSelf();
                var subPortals = newForm.GetComponentsInChildren<Portal>();
                foreach (var subPortal in subPortals)
                {
                    if (depth!=0) subPortal.playerCam = portal.playerCam;
                    portal.playerCam.GetComponent<MainCamera>().AddPortal(subPortal);
                    //subPortal.playerCam.gameObject.AddComponent<MainCamera>();
                    
                    if (subPortal.portalName == portal.linkPortalName)
                    {
                        
                        portal.linkedPortal = subPortal;
                        subPortal.linkedPortal = portal;
                        subPortal.StartPortalRender();
                        portal.StartPortalRender();
                       
                        break;
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
