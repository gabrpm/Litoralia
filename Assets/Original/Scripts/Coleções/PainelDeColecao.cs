using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PainelDeColecao : MonoBehaviour
{
    [SerializeField] GameObject elementoDeColecao;
    ElementoDeColecao[] elementosFilhos;
    bool jaCarregado = false;

    private void OnEnable() {

        if(!jaCarregado) {
            AjustarPainelAColecao();
            jaCarregado = true;
        }
        elementosFilhos = GetComponentsInChildren<ElementoDeColecao>();
        AtualizarTodosOsElementos();
    }

    public void AjustarPainelAColecao() {

        GameObject go = null;
        foreach (Especie sp in GerenciadorDeColecoes.instancia.colecaoDeEspecies.ListaDeEspecies) {
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

}
