using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PessoaConscientizavel", menuName = "Biodiversidade em jogo/Pessoa/Conscientizavel", order = 0)]
public class Pessoa_Conscientizavel : Pessoa
{
    [SerializeField] bool conscientizada;
    [SerializeField] int passosParaConsciencia;
    int passoAtual = 0;

    public bool Conscientizada {get{return conscientizada;}}
    public int PassosParaConsciencia {get{return passosParaConsciencia;}}
    public int PassoAtual {get{return passoAtual;}}

    private void OnEnable() {
        conscientizada = false;
        encontrada = false;
        passoAtual = 0;
    }

    override public void Conscientizar() {
        passoAtual++;
        if (passoAtual >= passosParaConsciencia)
        {
            conscientizada = true;
        }
    }

}
