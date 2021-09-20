using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisorCamera : MonoBehaviour
{
    [SerializeField] SpriteRenderer cruz;
    [SerializeField] Especie especieVista = null;
    [SerializeField] SpriteRenderer flash;
    
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.GetComponent<EspecieInfo>()) {
            if(!other.gameObject.GetComponent<EspecieInfo>().DadosEspecie.disponivelNaColecao) {
                cruz.color = Color.green;
                especieVista = other.gameObject.GetComponent<EspecieInfo>().DadosEspecie;
            } else {
                cruz.color = Color.red;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
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

    public void DispararFlash() {
        StartCoroutine(CorrotinaFlash());
    }

    public IEnumerator CorrotinaFlash() {
        flash.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        flash.gameObject.SetActive(false);
    }

    public void DesligarFlash() {
        flash.gameObject.SetActive(false);
    }
}
