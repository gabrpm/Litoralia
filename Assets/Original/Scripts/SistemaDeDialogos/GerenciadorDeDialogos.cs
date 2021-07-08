using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;
using TMPro;

public class GerenciadorDeDialogos : Singleton<GerenciadorDeDialogos>
{
    static public bool DialogoAtivo = false;
    [SerializeField] GameObject caixaDeDialogo;
    [SerializeField] GameObject containerNPC;
    [SerializeField] GameObject containerJogador;
    [SerializeField] TextMeshProUGUI textoNPC;
    [SerializeField] TextMeshProUGUI textoJogador;
    [SerializeField] TextMeshProUGUI[] opcoesJogador;

    // Start is called before the first frame update

    private void OnDisable() {
        FinalizarDialogoAtual(null);
    }

    public void IniciarDialogo(VIDE_Assign videAss) {
        
        //Esta checagem garante que um diálogo não seja iniciado se um já estiver sendo executado.
        if(VD.isActive) {

            if(!VD.nodeData.isPlayer) {
                ProximaFala();
            }
            return;
        }

        VD.OnNodeChange += AtualizarUI;
        VD.OnEnd += FinalizarDialogoAtual;

        DialogoAtivo = true;

        VD.BeginDialogue(videAss);
        caixaDeDialogo.SetActive(true);
    }

    public void AtualizarUI(VD.NodeData dadosDoNo) {
        
        containerJogador.SetActive(false);
        containerNPC.SetActive(false);

        if(dadosDoNo.isPlayer) {
            containerJogador.SetActive(true);
            if(dadosDoNo.tag == "interativo") {
                textoJogador.gameObject.SetActive(false);
            } else {
                textoJogador.gameObject.SetActive(true);
            }
            
            for(int i = 0; i < opcoesJogador.Length; i++) {
                if(i < dadosDoNo.comments.Length) {
                    opcoesJogador[i].transform.parent.gameObject.SetActive(true);
                    opcoesJogador[i].text = dadosDoNo.comments[i];
                } else {
                    opcoesJogador[i].transform.parent.gameObject.SetActive(false);
                }
            }

        } else {
            containerNPC.SetActive(true);

            textoNPC.text = dadosDoNo.comments[dadosDoNo.commentIndex];
            
        }
        

    }
    public void FinalizarDialogoAtual(VD.NodeData dadosDoNo) {
        VD.OnNodeChange -= AtualizarUI;
        VD.OnEnd -= FinalizarDialogoAtual;

        DialogoAtivo = false;

        VD.EndDialogue();
        caixaDeDialogo.SetActive(false);
    }

    public void EscolherOpcao(int indice) {
        VD.nodeData.commentIndex = indice;
        ProximaFala();
    }

    public void ProximaFala() {
        VD.Next();
    }

}
