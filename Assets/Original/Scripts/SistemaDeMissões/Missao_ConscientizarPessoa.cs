using UnityEngine;

[CreateAssetMenu(fileName = "Missao_ConscientizarPessoa", menuName = "Biodiversidade em jogo/Missao/ConscientizarPessoa", order = 2)]
public class Missao_ConscientizarPessoa : Missao
{
    [SerializeField] Pessoa_Conscientizavel[] pessoasObjetivo = null;

    public override void ChecarMissao()
    {
        for (int i = 0; i < pessoasObjetivo.Length; i++)
        {
            if(!pessoasObjetivo[i].Conscientizada) {
                return;
            }
        }
        ConcluirMissao();
    }
}
