using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class LancadorDeMissao : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Missao missaoASerLancada = null;
    [SerializeField] VIDE_Assign videAss;
    [SerializeField] int especies;
    [SerializeField] int nodeDeConversaFinal;
    [SerializeField] bool lancador;

    private void Awake() {
        videAss = GetComponent<VIDE_Assign>();
    }


    private void Update() {

        if(!lancador) {
            return;
        }
        
        if(missaoASerLancada.Concluida) {
            videAss.overrideStartNode = nodeDeConversaFinal;
        }
    }

    public void LancarMissao() {
        GerenciadorDeMissoes.instancia.AdicionarMissao(missaoASerLancada);
        Debug.Log("Missão lançada.");
        StartCoroutine(GerenciadorDeMissoes.instancia.ExibirPopUpMissao(missaoASerLancada));
        GerenciadorDeMissoes.instancia.ChecarMissoesAtivas();
    }


    public void OnPointerDown (PointerEventData eventData) {
        if(eventData.button.ToString() == "Right") {
            return;
        }
        if(!EstadoJogo.modoFotografia)
            GerenciadorDeDialogos.instancia.IniciarDialogo(videAss);
    }
}
