using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PessoaConscientizavel", menuName = "Biodiversidade em jogo/Pessoa/Conscientizavel", order = 0)]
public class Pessoa_Conscientizavel : Pessoa
{
    [SerializeField] bool conscientizada;

    public bool Conscientizada {get{return conscientizada;}}

    private void OnEnable() {
        conscientizada = false;    
    }

    override public void Conscientizar() {
        conscientizada = true;
    }
}
