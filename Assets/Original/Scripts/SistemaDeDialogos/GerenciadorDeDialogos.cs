using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GerenciadorDeDialogos : Singleton<GerenciadorDeDialogos>
{
    [Header("Diálogo")]
    static public bool DialogoAtivo = false;
    [Header("Eventos")]
    [SerializeField] Evento evento_InicioDialogo;
    [SerializeField] Evento evento_FinalDialogo;
    [Header("GOs")]
    [SerializeField] GameObject caixaDeDialogo;
    [SerializeField] GameObject containerNPC;
    [SerializeField] GameObject containerJogador;
    [SerializeField] GameObject botaoAvancar;
    [Header("Letreiros e Imagens")]
    [SerializeField] TextMeshProUGUI textoNPC;
    [SerializeField] TextMeshProUGUI textoJogador;
    [SerializeField] TextMeshProUGUI[] opcoesJogador;
    [SerializeField] TextMeshProUGUI letreiroNome;
    [SerializeField] Image imagemDialogo;
    [Header("Pessoa")]
    [SerializeField] Pessoa pessoaDialogadora;
    [SerializeField]bool proxFalaHabilitada = false;

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

        //VD.localizationEnabledSET = true;
        //VD.SetCurrentLanguage(EstadoJogo.localizacao);
        //Debug.Log(VD.currentLanguage);

        pessoaDialogadora = videAss.gameObject.GetComponent<Conversador>().Dialogador;

        evento_InicioDialogo.Ocorrido();
        
        //Esta checagem garante que um diálogo não seja iniciado se um já estiver sendo executado.
        if(VD.isActive) {

            if(!VD.nodeData.isPlayer || VD.nodeData.tag != "interativo") {
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
                        opcoesJogador[i].text = ChecarEModificarNomes(dadosDoNo.comments[i]);
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

                textoJogador.text = ChecarEModificarNomes(dadosDoNo.comments[dadosDoNo.commentIndex]);

            }
        } else {
            containerNPC.SetActive(true);
            botaoAvancar.gameObject.SetActive(true);

            textoNPC.text = ChecarEModificarNomes(dadosDoNo.comments[dadosDoNo.commentIndex]);   
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
        Debug.Log("Escolhida:" + indice.ToString());
        VD.nodeData.commentIndex = indice;

        if(proxFalaHabilitada) {
            ProximaFala();
        } else {
            proxFalaHabilitada = true;
        }

    }

    public void ProximaFala() {

        //VD.SetCurrentLanguage(EstadoJogo.localizacao);
        Debug.Log(VD.currentLanguage);
        
        if(VD.nodeData.tag == "limitado") {
            ChecarInteracoes((int)VD.nodeData.extraVars["limite"],(int)VD.nodeData.extraVars["trocarPara"]);
        }

        if(VD.nodeData.isPlayer && VD.nodeData.tag != "interativo") {
            if(VD.nodeData.comments.Length - 1 > VD.nodeData.commentIndex) {
                VD.nodeData.commentIndex++;
                AtualizarUI(VD.nodeData);
            } else {
                VD.Next();
            }
        } else{
            VD.Next();
        }
        
    }

    public void AjustarImagem() {
        if(!VD.nodeData.isPlayer) {
            imagemDialogo.color =  DadosDoJogador.instancia.Cor;
            imagemDialogo.color =  VD.assigned.gameObject.GetComponent<SpriteRenderer>().color;
            letreiroNome.text = pessoaDialogadora.Nome;
        } else if(VD.nodeData.isPlayer) {
            imagemDialogo.color = DadosDoJogador.instancia.Cor;
            letreiroNome.text = DadosDoJogador.instancia.Nome;
        }
    }

    public void ChecarInteracoes(int l, int n) {
        if(VD.assigned.interactionCount >= l-1) {
            VD.assigned.overrideStartNode = n;
        }
    }

    public void AlterarLocalizacao(string loc) {
        
        EstadoJogo.localizacao = loc;
        //Debug.Log(VD.GetLanguages().Length);
        //Debug.Log(VD.GetLanguages()); 
    }

    public string ChecarEModificarNomes(string texto)
    {
        string textoMod = texto;
        Debug.Log(texto);
        if (texto.Contains("_nome_"))
        {
            textoMod = textoMod.Replace("_nome_", DadosDoJogador.instancia.Nome);
        }

        if(texto.Contains("_x_"))
        {
            textoMod = textoMod.Replace("_x_", DadosDoJogador.instancia.Pronome);
        }

        if (texto.Contains("_meu/minha_"))
        {
            if (DadosDoJogador.instancia.Pronome == "a")
            {
                textoMod = textoMod.Replace("_meu/minha_", "minha");
            } 
            else if(DadosDoJogador.instancia.Pronome == "o")
            {
                textoMod = textoMod.Replace("_meu/minha", "meu");
            }
        }

        return textoMod;
    }
}
