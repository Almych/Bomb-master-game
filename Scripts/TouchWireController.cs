using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class TouchWireController : MonoBehaviour
{
    
    public bool isPressed = false;
    [SerializeField] private TrafficColors traffic;
    private float cutCoolDown = 0.2f;
    private PlaySoundEffect soundEffect;
    private RaycastHit hit;
   
    

    private void Start()
    {
        soundEffect = GetComponent<PlaySoundEffect>();
    }
    
    public void Updater()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Wire") && traffic.CheckNodeColor(hit.collider.GetComponent<Renderer>().material))
                {
                   StartCoroutine(CutWireAnimation(hit.collider.transform.GetChild(0).gameObject));
                    soundEffect.PlayEffect();
                }
                else isPressed = false;
            }
            else isPressed = false;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
           

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Wire") && traffic.CheckNodeColor(hit.collider.GetComponent<Renderer>().material))
                {
                    StartCoroutine(CutWireAnimation(hit.collider.transform.GetChild(0).gameObject));
                    soundEffect.PlayEffect();
                }
                else isPressed = false;
            }
            else isPressed = false;
        }
    }

    private  IEnumerator CutWireAnimation (GameObject wireCutZone)
    {
        isPressed = true;
        wireCutZone.SetActive(false);
        yield return new WaitForSeconds(cutCoolDown);
                wireCutZone.SetActive(true);
                
            
        
           
    }
  

   
}
