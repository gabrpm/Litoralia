using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Missao_RegistrarSp", menuName = "Biodiversidade em jogo/Missao/RegistrarSp", order = 0)]
public class Missao_RegistrarSp : Missao
{
    [SerializeField] Especie[] especiesParaRegistrar = null;

    public override void ChecarMissao()
    {
        for (int i = 0; i < especiesParaRegistrar.Length; i++)
        {
            if(!especiesParaRegistrar[i].disponivelNaColecao) {
                return;
            }
        }
        ConcluirMissao();
    }
}
