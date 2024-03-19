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
    public GameObject releaseButton, cutButton, addButton;

    //Asignados desde codigo
    private Camera cam;
    private GameObject itemSelected, itemGrabbed;
    private Vector3 hitPosition;
    [SerializeField] private float maxDistance;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance))
        {
            HandleRaycast(hit);
        }
        else
        {
            DesactivarBotones();
        }

        if(itemGrabbed != null)
        {
            itemGrabbed.transform.position = holdPosition.position;
            itemGrabbed.transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        }
    }

    private void HandleRaycast(RaycastHit hit)
    {
        itemSelected = hit.transform.gameObject;

        //Agarrar Boton
        if (hit.transform.GetComponent<ItemToGrab>() && itemGrabbed == null)
        {
            DesactivarBotones();
            grabButton.SetActive(true);
        }
        else if(itemGrabbed != null)
        {
            //Cortar botón
            if (itemGrabbed.CompareTag("Cuchillo") && itemSelected.GetComponent<CuttableObject>())
            {
                DesactivarBotones();
                cutButton.SetActive(true);
            }
            //Agregar al platillo boton
            else if (itemGrabbed.GetComponent<Ingrediente>() && itemSelected.GetComponent<Platillo>())
            {
                DesactivarBotones();
                addButton.SetActive(true);
            }
            //Soltar Boton
            else if (IsHorizontalCollision(hit))
            {
                DesactivarBotones();
                releaseButton.SetActive(true);
                circlePrefab.SetActive(true);
                hitPosition = hit.point;
                circlePrefab.transform.position = hitPosition;
            }
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
        cutButton.SetActive(false);
        addButton.SetActive(false);
    }

    public void Agarrar()
    {
        itemGrabbed = itemSelected;
        itemSelected = null;
        itemGrabbed.transform.position = holdPosition.position;
        itemGrabbed.GetComponent<Rigidbody>().useGravity = false;
    }

    public void Soltar()
    {
        itemGrabbed.transform.position = hitPosition + new Vector3(0f, itemGrabbed.GetComponent<Renderer>().bounds.size.y/2, 0f);
        itemGrabbed.GetComponent<Rigidbody>().useGravity = true;
        itemGrabbed = null;
    }

    public void Cortar()
    {
        itemSelected.GetComponent<CuttableObject>().Cortar();
    }

    public void AñadirIngrediente()
    {
        Platillo p = itemSelected.GetComponent<Platillo>();
        p.ingredientRecieved = itemGrabbed.GetComponent<Ingrediente>();
        if (p.Validar())
        {
            //Si es aceptado, cambia la accion según el tipo de agregado
            if (itemGrabbed.CompareTag("Ingrediente"))
            {
                Destroy(itemGrabbed);
                itemGrabbed = null;
            }
            else if (itemGrabbed.CompareTag("Condimento"))
            {

            }
            else if (itemGrabbed.CompareTag("Bowl"))
            {

            }
        }
    }

    public void Mezclar()
    {
        Bowl b = itemSelected.GetComponent<Bowl>();
        if (b.ready)
        {
            b.Batir();
        }
    }

    bool IsHorizontalCollision(RaycastHit hit)
    {
        //return hit.normal == Vector3.up;
        return Vector3.Dot(hit.normal, Vector3.up) > 0.99f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
    }
}
