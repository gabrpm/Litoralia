using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GerenciadorDeMissoes : Singleton<GerenciadorDeMissoes>
{
    public List<Missao> missoesAtivas = new List<Missao>();
    public List<Missao> missoesConcluidas = new List<Missao>();

    [SerializeField] GameObject painelNovaMissao;
    [SerializeField] TextMeshProUGUI letreiroNovaOuConcluida;
    [SerializeField] TextMeshProUGUI letreiroTitulo;
    [SerializeField] TextMeshProUGUI letreiroDescricao;
    [SerializeField] GameObject containerMissoes;
    [SerializeField] GameObject conjuntoPaineisDeMissao;
    [SerializeField] GameObject prefabPainelDeMissao;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update() {
        ChecarMissoesAtivas();
    }

    public void AdicionarMissao(Missao m) {
        missoesAtivas.Add(m);
        GameObject novoPainel = Instantiate(prefabPainelDeMissao,conjuntoPaineisDeMissao.transform);
        novoPainel.GetComponent<PainelDeMissao>().AtribuirMissao(m);
    }

    public void ChecarMissoesAtivas() {
        //Debug.Log("Gmissoes sendo chamado");
        for (int i = missoesAtivas.Count - 1; i >= 0 ; i--)
        {
            missoesAtivas[i].ChecarMissao();

            if(missoesAtivas[i].Concluida) {
                StartCoroutine(ExibirPopUpMissao(missoesAtivas[i]));
                missoesConcluidas.Add(missoesAtivas[i]);
                missoesAtivas.RemoveAt(i);
            }
        }
    }

    public IEnumerator ExibirPopUpMissao(Missao m) {

        letreiroTitulo.text = m.Nome;

        if(m.Concluida) {
            letreiroNovaOuConcluida.text = "MISSÃO CONCLUÍDA!";
            letreiroDescricao.text = m.TextoMissaoFinalizada;
        } else {
            letreiroNovaOuConcluida.text = "NOVA MISSÃO!";
            letreiroDescricao.text = m.Descricao;            
        }

        LeanTween.moveY(painelNovaMissao.GetComponent<RectTransform>(), -183f, 1f);
        yield return new WaitForSeconds(8f);
        LeanTween.moveY(painelNovaMissao.GetComponent<RectTransform>(), 183f, 1f);

    }

    public void ExibirEsconderMissoesAtivas(bool e) {

        containerMissoes.SetActive(e);
        
    }
}
