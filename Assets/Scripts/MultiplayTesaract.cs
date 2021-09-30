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
    public int step=1000;
    // Start is called before the first frame update
    public void Awake()
    {
        
    }
    void Start()
    {
        
        //LayersCounter.depth = depth;
    }
    
    public void CloneSelf()
    {
        if ((depth > 0)&&(depth==LayersCounter.GetStep()))
        {
            portalsClone.Clear();
            var trashes = GetComponentsInChildren<Portal>();
            foreach (var trash in trashes)
            {
                if (!trash.main)
                {
                    portalsClone.Add(trash);//добавили все порталы объекта, которые не являются связующими
                    
                }
                else
                {
                   // mainPortalCam = trash.portalCam;
                }

            }
            foreach (var portal in portalsClone)
            {
                var newForm = Instantiate(gameObject, transform.position + step * LayersCounter.GetNewLayer(), Quaternion.identity);// для каждого портали создали новый оюъект
                newForm.GetComponent<MultiplayTesaract>().depth = depth - 1;//уменьшили шаг глубины
                newForm.GetComponent<MultiplayTesaract>().portalsClone.Clear();//очистили массив
                newForm.name = portal.name + "_"+ newForm.name;//изменили имя
                //newForm.GetComponent<MultiplayTesaract>().CloneSelf();
                var subPortals = newForm.GetComponentsInChildren<Portal>();// получаю все порталы нового объекта

                
                

                foreach (var subPortal in subPortals)//перебор новых порталов
                {
                    
                    if (subPortal.portalName == portal.linkPortalName)// для нового связуюшего портала
                    {
                        foreach  (var mesh in subPortal.GetComponentsInChildren<MeshRenderer>())
                        {
                            mesh.enabled = false;
                        }
                        portal.linkedPortal = subPortal;// установка связи между ними 
                        subPortal.linkedPortal = portal;
                        subPortal.StartPortalRender();
                        portal.StartPortalRender();
                        subPortal.main = true;
                        
                    }
                    
                }
                foreach (var subPortal in subPortals)//новый перебор
                {

                    if (subPortal.portalName != portal.linkPortalName) subPortal.playerCam = portal.linkedPortal.portalCam;// для остальных порталов установить зависимость от новой камеры
                    else subPortal.playerCam = subPortal.linkedPortal.playerCam;
                    if (subPortal.playerCam.GetComponent<MainCamera>() == null)
                    {
                        subPortal.playerCam.gameObject.AddComponent<MainCamera>();
                    }

                    if (!subPortal.playerCam.GetComponent<MainCamera>().ContainPortal(subPortal))
                    {

                        subPortal.playerCam.GetComponent<MainCamera>().AddPortal(subPortal);
                    }
                    
                    if ((subPortal.portalName != portal.linkPortalName)&& (subPortal.portalName != portal.portalName))
                    {
                       
                        foreach (var subPortal2 in subPortals)
                        {
                            if ((subPortal.portalName == subPortal2.linkPortalName))
                            {

                                subPortal2.linkedPortal = subPortal;
                                subPortal.linkedPortal = subPortal2;
                                subPortal.StartPortalRender();
                                subPortal2.StartPortalRender();
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
        if (Input.GetKeyDown(KeyCode.I))
        {
            CloneSelf();
        }
    }
}
