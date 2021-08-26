using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoJogador : MonoBehaviour
{
    bool interacaoHabilitada = true;
    [SerializeField] VIDE_Assign interlocutorAss = null;

    public void Interagir() {
        
        if(!interacaoHabilitada) {
            return;
        }
        
        if (interlocutorAss != null) {
            GerenciadorDeDialogos.instancia.IniciarDialogo(interlocutorAss);
            Debug.Log("Interagindo");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<VIDE_Assign>()) {
            interlocutorAss = other.gameObject.GetComponent<VIDE_Assign>();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.GetComponent<VIDE_Assign>() == interlocutorAss) {
            interlocutorAss = null;
        }
    }

    public void HabilitarInteracao(bool b) {
        interacaoHabilitada = b;
    }
}
