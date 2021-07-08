using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisorCamera : MonoBehaviour
{
    [SerializeField] SpriteRenderer cruz;
    [SerializeField] Especie especieVista = null;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<EspecieInfo>()) {
            if(!other.gameObject.GetComponent<EspecieInfo>().DadosEspecie.disponivelNaColecao) {
                cruz.color = Color.green;
                especieVista = other.gameObject.GetComponent<EspecieInfo>().DadosEspecie;
            } else {
                cruz.color = Color.red;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.GetComponent<EspecieInfo>()) {
            cruz.color = Color.white;
            especieVista = null;
        }
    }
    
    public void Fotografar() {
        if(especieVista != null) {
            GerenciadorDeColecoes.instancia.DisponibilizarNaColecao(especieVista);
        }
    }
}
