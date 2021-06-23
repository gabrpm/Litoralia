using UnityEngine;

public enum RiscoDeExtincao {POUCO_PREOCUPANTE, QUASE_AMEACADA, VULNERAVEL, EM_PERIGO, CRITICAMENTE_AMEACADA, EXTINTA_NA_NATUREZA, EXTINTA}
[CreateAssetMenu(fileName = "Especie", menuName = "Biodiversidade em jogo/Especie", order = 0)]

public class Especie : ScriptableObject {
    [Tooltip("O nome comum da espécie.")]
    public string nomeComum;
    public string nomeCientifico;
    [Tooltip("A classificação taxonômica da espêcie. Aqui talvez seja melhor não especificar muito. Talvez até Ordem.")]
    public string classificacao;
    [Tooltip("Em que ambientes essa espécie ocorre?")]
    public string ocorrenciaNaNatureza;
    public RiscoDeExtincao grauDeAmeaca;
    [Tooltip("Essa frase pode ser uma curiosidade, uma referência ou uma piada.")]
    public string frase;
    
}