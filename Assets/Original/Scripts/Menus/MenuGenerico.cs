using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGenerico : MonoBehaviour
{
    public void IniciarJogo(int cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
