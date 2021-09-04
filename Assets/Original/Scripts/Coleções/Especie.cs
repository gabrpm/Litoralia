using UnityEngine;

public enum RiscoDeExtincao {POUCO_PREOCUPANTE, QUASE_AMEACADA, VULNERAVEL, EM_PERIGO, CRITICAMENTE_AMEACADA, EXTINTA_NA_NATUREZA, EXTINTA}
public enum Ecossistema {MAR, COSTA, ESTUARIO, TODOS}

[CreateAssetMenu(fileName = "Especie", menuName = "Biodiversidade em jogo/Especie", order = 0)]
public class Especie : ScriptableObject {

    [Tooltip("O nome comum da espécie.")]
    [SerializeField] string nomeComum;
    [SerializeField] string nomeCientifico;
    [Tooltip("A classificação taxonômica da espêcie. Aqui talvez seja melhor não especificar muito. Talvez até Ordem.")]
    [SerializeField] string classificacao;
    [Tooltip("Em que ambientes essa espécie ocorre?")]
    [SerializeField] string ocorrenciaNaNatureza;
    [SerializeField] RiscoDeExtincao grauDeAmeaca;
    [Tooltip("Essa frase pode ser uma curiosidade, uma referência ou uma piada.")]
    [SerializeField] string frase;
    [SerializeField] Sprite imagemNaNatureza;
    [SerializeField] Sprite imagemNoJogo;
    [SerializeField] bool ocorreNoMar;
    [SerializeField] bool ocorreNaCosta;
    [SerializeField] bool ocorreNoEstuario;
    public bool disponivelNaColecao;

    public string NomeComum {get {return nomeComum;}}
    public string NomeCientifico {get {return nomeCientifico;}}
    public string Classificacao {get {return classificacao;}}
    public string OcorrenciaNaNatureza {get {return ocorrenciaNaNatureza;}}
    public string Frase {get {return frase;}}
    public RiscoDeExtincao GrauDeAmeaca {get {return grauDeAmeaca;}}
    public Sprite ImagemNaNatureza {get {return imagemNaNatureza;}}
    public Sprite ImagemNoJogo {get {return imagemNoJogo;}}
    public bool OcorreNoMar {get{return ocorreNoMar;}}
    public bool OcorreNaCosta {get{return ocorreNaCosta;}}
    public bool OcorreNoEstuario {get{return ocorreNoEstuario;}}

    private void OnEnable() {
        disponivelNaColecao = false;
    }

}