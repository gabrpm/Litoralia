using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColecaoDeEspecies", menuName = "Biodiversidade em jogo/ColecaoDeEspecies", order = 0)]
public class ColecaoDeEspecies : ScriptableObject {
    [SerializeField] List<Especie> listaDeEspecies = new List<Especie>();

    public List<Especie> ListaDeEspecies {get {return listaDeEspecies;} }

}