using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PainelDeColecao : MonoBehaviour
{
    [SerializeField] GameObject elementoDeColecao;
    ElementoDeColecao[] elementosFilhos;
    [SerializeField] int capacidade = 15;
    bool jaCarregado = false;

    private void OnEnable() {

        if(!jaCarregado) {
            //AjustarPainelAColecao();
            jaCarregado = true;
        }
        elementosFilhos = GetComponentsInChildren<ElementoDeColecao>();
        AtualizarTodosOsElementos();
    }

    public void AjustarPainelAColecao() {

        GameObject go;
        foreach (Especie sp in GerenciadorDeColecoes.instancia.colecaoDeEspecies.ListaDeEspecies) {
            if (Cheio()) return;
            go = Instantiate(elementoDeColecao,transform);
            go.GetComponent<ElementoDeColecao>().item = sp;
            go.GetComponent<ElementoDeColecao>().Atualizar();
        }
    }

    public void AtualizarTodosOsElementos() {
        
        foreach (ElementoDeColecao el in elementosFilhos)
        {
            el.Atualizar();
        }
    }

    public bool Cheio()
    {
        if(transform.childCount < capacidade)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void MoverPara(float aonde, float tempo)
    {
        LeanTween.moveX(GetComponent<RectTransform>(), aonde, tempo);
    }

}
