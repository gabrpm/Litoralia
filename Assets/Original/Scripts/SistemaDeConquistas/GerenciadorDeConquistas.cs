using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeConquistas : MonoBehaviour
{
    [SerializeField] GameObject painelFinal;
    int progresso = 0;

    private void Update()
    {
        if(progresso >= 2)
        {
            if (!painelFinal.activeInHierarchy)
            {
                painelFinal.SetActive(true);
            }
        }
    }

    public void Progredir()
    {
        progresso++;
    }

}
