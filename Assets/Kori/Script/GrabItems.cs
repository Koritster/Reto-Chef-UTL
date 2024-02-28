using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItems : MonoBehaviour
{
    //Asignados desde el editor
    [SerializeField] private Transform holdPosition;
    [SerializeField] private GameObject circlePrefab;

    [Header("Botones de accion")]
    public GameObject grabButton;
    public GameObject releaseButton;

    //Asignados desde codigo
    private Camera cam;
    [SerializeField]
    private GameObject itemSelected, itemGrabbed;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
        {
            if( itemGrabbed == null && hit.transform.GetComponent<ItemToGrab>()) 
            {
                DesactivarBotones();
                itemSelected = hit.transform.gameObject;
                grabButton.SetActive(true);
            }
            else if(itemGrabbed != null && IsHorizontalCollision(hit))
            {
                DesactivarBotones();
                releaseButton.SetActive(true);
                circlePrefab.SetActive(true);
                circlePrefab.transform.position = hit.point;
            }
            else
            {
                DesactivarBotones();
            }
        }
        else
        {
            DesactivarBotones();
            grabButton.SetActive(false);
        }
        Debug.Log(hit.transform.name);
    }

    private void DesactivarBotones()
    {
        grabButton.SetActive(false);
        releaseButton.SetActive(false);
        circlePrefab.SetActive(false);
    }

    public void Agarrar()
    {
        itemGrabbed = itemSelected;
        itemGrabbed.transform.position = holdPosition.position;
    }



    public void Soltar()
    {

    }

    bool IsHorizontalCollision(RaycastHit hit)
    {
        return hit.normal == Vector3.up;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * 10f);
    }
}
