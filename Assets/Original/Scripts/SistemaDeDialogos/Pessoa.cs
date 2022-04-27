using UnityEngine;

[CreateAssetMenu(fileName = "PessoaNaoConscientizavel", menuName = "Biodiversidade em jogo/Pessoa/NaoConscientizavel", order = 0)]
public class Pessoa : ScriptableObject {
    [SerializeField] string nome;
    [SerializeField] int idade;
    [SerializeField] protected bool encontrada;

    public string Nome {get{return nome;}}
    public int Idade {get{return idade;}}
    public bool Encontrada { get { return encontrada; } }

    private void OnEnable()
    {
        encontrada = false;
    }

    virtual public void Conscientizar() {
        Debug.LogError("Esta pessoa não pode ser conscientizada.");
    }

    public void Encontrar()
    {
        if(!encontrada)
            encontrada = true;
    }
}