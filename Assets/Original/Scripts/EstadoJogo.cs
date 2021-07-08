using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Modo {EXPLORACAO, FOTOGRAFIA}
static class EstadoJogo
{
    public static bool modoFotografia = false;
    public static string nomePersonagem;
    public static bool colecaoAberta;
    public static int quantidadeTotalSp;
    public static int quantidadeRegistradaSp;
}
