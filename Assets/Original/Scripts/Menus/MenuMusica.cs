using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuMusica : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI letreiroTituloMusica;
    [SerializeField] public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = Volume();
        AlterarNomeMusica();
    }

    public void AlterarVolume(float v)
    {
        SistemaSom.instancia.AlterarVolume(v);
    }

    public float Volume()
    {
        return SistemaSom.instancia.VolumeAtual();
    }

    public void ProximaMusica()
    {
        SistemaSom.instancia.MudarMusica(1);
        AlterarNomeMusica();
    }

    public void MusicaAnterior()
    {
        SistemaSom.instancia.MudarMusica(-1);
        AlterarNomeMusica();
    }

    public void AlterarNomeMusica()
    {
        letreiroTituloMusica.text = SistemaSom.instancia.MusicaAtual();
    }

}
