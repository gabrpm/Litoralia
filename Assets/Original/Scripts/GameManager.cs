using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Modo { EXPLORACAO, FOTOGRAFIA }
static class EstadoJogo
{
    public static bool modoFotografia = false;
    public static string nomePersonagem;
    public static bool colecaoAberta;
    public static int quantidadeTotalSp;
    public static int quantidadeRegistradaSp;
    public static Ecossistema ecossitemaAtual = Ecossistema.COSTA;
    public static string localizacao;
}

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Evento evento_EntrarFotografia;
    [SerializeField] Evento evento_SairFotografia;

    public void AlterarModo() {
        if(GerenciadorDeDialogos.DialogoAtivo) {
            return;
        }

        if(EstadoJogo.colecaoAberta) {
            return;
        }
        
        if(EstadoJogo.modoFotografia == true) {
            evento_SairFotografia.Ocorrido();
            Cursor.visible = true;
            EstadoJogo.modoFotografia = false;
        } else {
            evento_EntrarFotografia.Ocorrido();
            Cursor.visible = false;
            EstadoJogo.modoFotografia = true;
        }
    }

    public void ExibirNoCelular(GameObject go)
    {
        Debug.Log(SystemInfo.deviceType);
        if (SystemInfo.deviceType == DeviceType.Unknown || SystemInfo.deviceType == DeviceType.Unknown)
        {
            go.SetActive(true);
        }
    }
}
