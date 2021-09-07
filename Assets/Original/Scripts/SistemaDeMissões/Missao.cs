using UnityEngine;

public enum TipoMissao {REGISTRAR, CONSCIENTIZAR}

public abstract class Missao : ScriptableObject {
    [SerializeField] protected string nome;
    //[SerializeField] TipoMissao tipo;
    [SerializeField] protected string descricao;
    [SerializeField] protected string textoMissaoFinalizada;
    [SerializeField] protected bool concluida = false;
    [Range(0,1)]
    protected float progresso = 0;

    public string Nome {get{return nome;}}
    public string Descricao {get{return descricao;}}
    public string TextoMissaoFinalizada {get{return textoMissaoFinalizada;}}
    public bool Concluida {get{return concluida;}}
    public float Progresso {get{return progresso;}}

    private void OnEnable() {
        concluida = false;
    }

    public void ConcluirMissao() {
        concluida = true;
        progresso = 1;
    }

    public void ProgredirMissao(float f) {
        progresso = f;
    }

    abstract public void ChecarMissao();
}