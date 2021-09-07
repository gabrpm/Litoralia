using UnityEngine;

[CreateAssetMenu(fileName = "Missao_RegistrarQuantidadeSpp", menuName = "Biodiversidade em jogo/Missao/RegistrarQuantidadeSpp", order = 1)]
public class Missao_RegistrarQuantidadeSpp : Missao {

    [SerializeField] private int quantidadeDeEspecies;
    [SerializeField] private int quantidadeAtual;
    [SerializeField] private Ecossistema emQueEcossistema = Ecossistema.TODOS;
    
    public int QuantidadeDeEspecies {get{return quantidadeDeEspecies;}}
    public Ecossistema EmQueEcossistema {get{return emQueEcossistema;}}

    private void OnEnable() {
        concluida = false;
        quantidadeAtual = 0;
    }

    override public void ChecarMissao() {
        quantidadeAtual = GerenciadorDeColecoes.instancia.QtdeDeSpRegistradas(emQueEcossistema);
        ProgredirMissao(quantidadeAtual/quantidadeDeEspecies);
        if(quantidadeAtual >= quantidadeDeEspecies) {
            ConcluirMissao();
        }
    }

}