using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InfoPanels : MonoBehaviour
{
    public GameObject[] pagesPanels;

    [SerializeField] private GameObject backBtn, nextBtn;
    [SerializeField] private int index = 0;


    private void Awake()
    {
        /*index = 0;
        Debug.Log(GameObject.FindGameObjectsWithTag("Help"));

        pagesPanels = GameObject.FindGameObjectsWithTag("Help");
        pagesPanels = pagesPanels.OrderBy(x => x.name).ToArray();

        */

        //Cerrar todo al inicio sin animación
        foreach (var page in pagesPanels)
        {
            page.SetActive(false);
        }

        AbrirPagina(index);

        ComprobarInicioFin();
    }

    private void CerrarPaginas()
    {
        foreach (var page in pagesPanels)
        {
            if (page == pagesPanels[index])
            {
                continue;
            }
            if (page.activeSelf)
            {
                AnimacionCerrarHijos(page);
                StartCoroutine(anim_CerrarPaginas(page));
            }
        }
    }

    private void AnimacionCerrarHijos(GameObject p)
    {
        for (int i = 0; i < p.transform.childCount; i++)
        {
            p.transform.GetChild(i).GetComponentInChildren<Animator>(true).Play("Cerrar");
        }
    }

    private void AnimacionabrirHijos(GameObject p)
    {
        for (int i = 0; i < p.transform.childCount; i++)
        {
            p.transform.GetChild(i).GetComponentInChildren<Animator>(true).Play("Abrir");
        }
    }

    private void ComprobarInicioFin()
    {
        backBtn.SetActive(true);
        nextBtn.SetActive(true);

        if (index == 0)
        {
            backBtn.SetActive(false);
        }
        else if (index == (pagesPanels.Length - 1))
        {
            nextBtn.SetActive(false);
        }
    }

    public void AbrirPagina(int pageNo)
    {
        index = pageNo;

        CerrarPaginas();

        pagesPanels[index].SetActive(true);

        AnimacionabrirHijos(pagesPanels[index]);
        ComprobarInicioFin();
    }

    public void AbrirPaginaSinAnimacion(int pageNo)
    {
        index = pageNo;

        CerrarPaginas();

        pagesPanels[index].SetActive(true);

        ComprobarInicioFin();
    }

    public void SiguientePagina()
    {
        AbrirPagina(index + 1);
    }

    public void AnteriorPagina()
    {
        AbrirPagina(index - 1);
    }

    IEnumerator anim_CerrarPaginas(GameObject p)
    {
        yield return new WaitForSeconds(1f);
        p.SetActive(false);
    }
}
