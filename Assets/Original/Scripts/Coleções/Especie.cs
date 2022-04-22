using UnityEngine;

public enum RiscoDeExtincao {N_AVALIADA, N_APLICAVEL, DADOS_INSUFICIENTES, POUCO_PREOCUPANTE, QUASE_AMEACADA, VULNERAVEL, EM_PERIGO, CRITICAMENTE_AMEACADA, REGIONALMENTE_EXTINTA, EXTINTA_NA_NATUREZA, EXTINTA}
public enum Ecossistema {MAR, COSTA, ESTUARIO, TODOS}

[CreateAssetMenu(fileName = "Especie", menuName = "Biodiversidade em jogo/Especie", order = 0)]
public class Especie : ScriptableObject {

    [Tooltip("O nome comum da espécie.")]
    [SerializeField] string nomeComum;
    [SerializeField] string nomeCientifico;

    [Header("Classificação")]
    [SerializeField] string reino;
    [SerializeField] string filo;
    [SerializeField] string classe;
    [SerializeField] string ordem;
    [SerializeField] string familia;
    [SerializeField] string genero;

    [Header("Ocorrência")]
    [SerializeField] string ocorrenciaNaNatureza;

    [Header("Ameaça")]
    [SerializeField] RiscoDeExtincao grauDeAmeaca;
    
    [Header("Frase e infos")]
    [TextArea(1,2)]
    [SerializeField] string frase;
    [SerializeField] string link;
    [TextArea(3,6)]
    [SerializeField] string info1;
    [TextArea(3, 6)]
    [SerializeField] string info2;
    [TextArea(3, 6)]
    [SerializeField] string info3;
    [TextArea(3, 6)]
    [SerializeField] string info4;
    
    [Header("Imagens")]
    [SerializeField] Sprite imagemNaNatureza;
    [SerializeField] Sprite imagemNoJogo;
    [SerializeField] bool ocorreNoMar;
    [SerializeField] bool ocorreNaCosta;
    [SerializeField] bool ocorreNoEstuario;
    public bool disponivelNaColecao;

    public string NomeComum {get {return nomeComum;}}
    public string NomeCientifico {get {return nomeCientifico;}}
    public string Reino {get {return reino;}}
    public string Filo {get {return filo;}}
    public string Classe {get {return classe;}}
    public string Ordem {get {return ordem;}}
    public string Familia {get {return familia;}}
    public string Genero {get {return genero;}}
    public string OcorrenciaNaNatureza {get {return ocorrenciaNaNatureza;}}
    public string Frase {get {return frase;}}
    public string Link {get {return link;}}
    public RiscoDeExtincao GrauDeAmeaca {get {return grauDeAmeaca;}}
    public string Info1 { get { return info1; } }
    public string Info2 { get { return info2; } }
    public string Info3 { get { return info3; } }
    public string Info4 { get { return info4; } }
    public Sprite ImagemNaNatureza {get {return imagemNaNatureza;}}
    public Sprite ImagemNoJogo {get {return imagemNoJogo;}}
    public bool OcorreNoMar {get{return ocorreNoMar;}}
    public bool OcorreNaCosta {get{return ocorreNaCosta;}}
    public bool OcorreNoEstuario {get{return ocorreNoEstuario;}}

    private void OnEnable() {
        disponivelNaColecao = false;
    }

}