using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class MissaoEProximoNo {
    public Missao missao;
    public TextAsset proxConversa;
}
public class LancadorDeMissao : Conversador, IPointerDownHandler
{
    [SerializeField] MissaoEProximoNo[] missoesALancar = null;
    int missaoAtual = 0;

    public void LancarMissao() {
        GerenciadorDeMissoes.instancia.AdicionarMissao(missoesALancar[missaoAtual].missao);
        Debug.Log("Missão lançada.");
        Debug.Log(dialogo.assignedDialogue);
        StartCoroutine(GerenciadorDeMissoes.instancia.ExibirPopUpMissao(missoesALancar[missaoAtual].missao));
        GerenciadorDeMissoes.instancia.ChecarMissoesAtivas();
    }

    public void VerificarRealizacaoDaMissao() {
        if(missoesALancar[missaoAtual].missao.Concluida) {
            //videAss.overrideStartNode = missoesALancar[missaoAtual].proxNo;
            dialogo.overrideStartNode = -1;
            dialogo.AssignNew(missoesALancar[missaoAtual].proxConversa.name);
            if(missaoAtual < missoesALancar.Length -1) {
                missaoAtual++;
            }
        }
    }

    override public void OnPointerDown (PointerEventData eventData) {
        if(eventData.button.ToString() == "Right") {
            return;
        }
        if(!EstadoJogo.modoFotografia){
            
            GetComponent<LancadorDeMissao>().VerificarRealizacaoDaMissao();
            GerenciadorDeDialogos.instancia.IniciarDialogo(dialogo);
        }
    }

}
