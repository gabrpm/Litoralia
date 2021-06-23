using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Evento", menuName = "Biodiversidade em jogo/Evento", order = 0)]
public class Evento : ScriptableObject {
    List<OuvinteEvento> listaOuvintes = new List<OuvinteEvento>();

    public void Registrar(OuvinteEvento ouvinte) {
        listaOuvintes.Add(ouvinte);
    }

    public void Desregistrar(OuvinteEvento ouvinte) {
        listaOuvintes.Remove(ouvinte);
    }

    public void Ocorrido() {
        for (int i = 0; i < listaOuvintes.Count; i++) {
            listaOuvintes[i].AoOcorrerEvento();
        }
    }
}