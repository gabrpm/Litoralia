using UnityEngine;

[CreateAssetMenu(fileName = "PessoaNaoConscientizavel", menuName = "Biodiversidade em jogo/Pessoa/NaoConscientizavel", order = 0)]
public class Pessoa : ScriptableObject {
    [SerializeField] string nome;
    [SerializeField] int idade;

    public string Nome {get{return nome;}}
    public int Idade {get{return idade;}}

    virtual public void Conscientizar() {
        Debug.LogError("Esta pessoa não pode ser conscientizada.");
    }
}