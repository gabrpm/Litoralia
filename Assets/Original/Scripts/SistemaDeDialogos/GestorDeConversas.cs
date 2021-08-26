using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GestorDeConversas : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] VIDE_Assign videAss;
    [SerializeField] int especies;
    [SerializeField] TextAsset conversaFinal;

    private void Awake() {
        videAss = GetComponent<VIDE_Assign>();
    }
    
    private void Update() {
        if(videAss.assignedDialogue == conversaFinal.name) {
            return;
        }
        if(GerenciadorDeColecoes.instancia.QtdeDeSpRegistradas() >= especies) {
            videAss.AssignNew(conversaFinal.name);
            videAss.overrideStartNode = -1;
        }
    }

    public void OnPointerDown (PointerEventData eventData) {
        if(eventData.button.ToString() == "Right") {
            return;
        }
        if(!EstadoJogo.modoFotografia)
            GerenciadorDeDialogos.instancia.IniciarDialogo(videAss);
    }
}
