using UnityEngine;

public enum TipoObjetivo {REGISTRAR, CONSCIENTIZAR}

[CreateAssetMenu(fileName = "Objetivo", menuName = "Biodiversidade em jogo/Objetivo", order = 0)]
public class Objetivo : ScriptableObject {
    [SerializeField] string nome;
    [SerializeField] TipoObjetivo tipo;
    [SerializeField] string descricao;

}