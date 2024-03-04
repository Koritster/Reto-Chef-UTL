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
    private Vector3 hitPosition;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
        {
            HandleRaycast(hit);
        }
        else
        {
            DesactivarBotones();
        }
    }

    private void HandleRaycast(RaycastHit hit)
    {
        //Agarrar Boton
        if (itemGrabbed == null && hit.transform.GetComponent<ItemToGrab>())
        {
            DesactivarBotones();
            itemSelected = hit.transform.gameObject;
            grabButton.SetActive(true);
        }
        //Soltar Boton
        else if (itemGrabbed != null && IsHorizontalCollision(hit))
        {
            DesactivarBotones();
            releaseButton.SetActive(true);
            circlePrefab.SetActive(true);
            hitPosition = hit.point;
            circlePrefab.transform.position = hitPosition;
        }
        else
        {
            DesactivarBotones();
        }
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
        itemGrabbed.GetComponent<Rigidbody>().useGravity = false;
    }



    public void Soltar()
    {
        itemGrabbed.transform.position = hitPosition + new Vector3(0f, itemGrabbed.GetComponent<Renderer>().bounds.size.y/2, 0f);
        itemGrabbed.GetComponent<Rigidbody>().useGravity = true;
        itemGrabbed = null;
    }

    bool IsHorizontalCollision(RaycastHit hit)
    {
        //return hit.normal == Vector3.up;
        return Vector3.Dot(hit.normal, Vector3.up) > 0.99f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * 10f);
    }
}
