using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GerenciadorDeDialogos : Singleton<GerenciadorDeDialogos>
{
    static public bool DialogoAtivo = false;
    [SerializeField] Evento evento_InicioDialogo;
    [SerializeField] Evento evento_FinalDialogo;
    [SerializeField] GameObject caixaDeDialogo;
    [SerializeField] GameObject containerNPC;
    [SerializeField] GameObject containerJogador;
    [SerializeField] GameObject botaoAvancar;
    [SerializeField] TextMeshProUGUI textoNPC;
    [SerializeField] TextMeshProUGUI textoJogador;
    [SerializeField] TextMeshProUGUI[] opcoesJogador;
    [SerializeField] Image imagemDialogo;
    bool proxFalaHabilitada = false;

    // Start is called before the first frame update

    private void OnDisable() {
        FinalizarDialogoAtual(null);
    }

    public void IniciarDialogo(VIDE_Assign videAss) {

        if (EstadoJogo.modoFotografia) {
            return;
        }

        if(EstadoJogo.colecaoAberta) {
            return;
        }

        evento_InicioDialogo.Ocorrido();
        
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
        botaoAvancar.SetActive(false);

        AjustarImagem();

        if(dadosDoNo.isPlayer) {
            containerJogador.SetActive(true);
            if(dadosDoNo.tag == "interativo") {
                botaoAvancar.gameObject.SetActive(false);
                textoJogador.gameObject.SetActive(false);

                for(int i = 0; i < opcoesJogador.Length; i++) {
                    if(i < dadosDoNo.comments.Length) {
                        opcoesJogador[i].transform.parent.gameObject.SetActive(true);
                        opcoesJogador[i].text = dadosDoNo.comments[i];
                        if(i == 0) {
                            proxFalaHabilitada = false;
                            opcoesJogador[i].transform.parent.GetComponent<Selectable>().Select();
                        }
                    } else {
                        opcoesJogador[i].transform.parent.gameObject.SetActive(false);
                    }
                }

            } else {
                for (int i = 0; i < opcoesJogador.Length; i++)
                {
                    opcoesJogador[i].transform.parent.gameObject.SetActive(false);
                }
                textoJogador.gameObject.SetActive(true);
                botaoAvancar.gameObject.SetActive(true);

                textoJogador.text = dadosDoNo.comments[dadosDoNo.commentIndex];
            }
        } else {
            containerNPC.SetActive(true);
            botaoAvancar.gameObject.SetActive(true);

            textoNPC.text = dadosDoNo.comments[dadosDoNo.commentIndex];   
        }
    }

    public void FinalizarDialogoAtual(VD.NodeData dadosDoNo) {
        VD.OnNodeChange -= AtualizarUI;
        VD.OnEnd -= FinalizarDialogoAtual;

        VD.EndDialogue();

        caixaDeDialogo.SetActive(false);

        evento_FinalDialogo.Ocorrido();
        
        DialogoAtivo = false;
    }

    public void EscolherOpcao(int indice) {
        
        VD.nodeData.commentIndex = indice;

        if(proxFalaHabilitada) {
            ProximaFala();
        } else {
            proxFalaHabilitada = true;
        }

    }

    public void ProximaFala() {

        if(VD.nodeData.tag == "limitado") {
            ChecarInteracoes((int)VD.nodeData.extraVars["limite"],(int)VD.nodeData.extraVars["trocarPara"]);
        }
        
        VD.Next();
        
    }

    public void AjustarImagem() {
        if(!VD.nodeData.isPlayer) {
            imagemDialogo.color =  new Color(255,0,151);
            imagemDialogo.color =  VD.assigned.gameObject.GetComponent<SpriteRenderer>().color;
        } else if(VD.nodeData.isPlayer) {
            imagemDialogo.color = DadosDoJogador.cor;
        }
    }

    public void ChecarInteracoes(int l, int n) {
        if(VD.assigned.interactionCount >= l-1) {
            VD.assigned.overrideStartNode = n;
        }
    }

}
