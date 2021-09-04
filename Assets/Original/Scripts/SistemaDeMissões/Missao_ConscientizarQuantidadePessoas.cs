using UnityEngine;

[CreateAssetMenu(fileName = "Missao_ConscientizarQuantidadePessoas", menuName = "Biodiversidade em jogo/Missao/ConscientizarQuantidadePessoas", order = 0)]
public class Missao_ConscientizarQuantidadePessoas : Missao {
    [SerializeField] private int quantidadeDePessoas;

    public int QuantidadeDePessoas {get{return quantidadeDePessoas;}}

    override public void ChecarMissao() {
        
    }
    
}
