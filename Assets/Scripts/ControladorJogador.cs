using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

//Esse componente necessita desses outros para funcionar corretamente:
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(MovimentacaoJogador))]


//Esta classe é responsável por captar o input dado pelo jogador e chamar as funções
//que controlam o jogador nos scripts necessários.
public class ControladorJogador : MonoBehaviour
{
    InputActions controles;
    PlayerInput input;
    MovimentacaoJogador scriptMovimentacao;
    ComportamentoCamera scriptCamera;
    
    void Awake()
    {
        controles = new InputActions();
        AtribuirScripts();
        input.onActionTriggered += Input_onActionTriggered;
    }

    void OnDisable() {
        input.onActionTriggered -= Input_onActionTriggered;
    }
    
    void AtribuirScripts() {
        input = GetComponent<PlayerInput>();
        scriptMovimentacao = GetComponent<MovimentacaoJogador>();
        scriptCamera = GetComponentInChildren<ComportamentoCamera>();
    }

    //Sempre que uma ação é realizada, as funções de controle são chamadas.
    private void Input_onActionTriggered(InputAction.CallbackContext obj) {

        if (obj.action.name == controles.Jogador.Mover.name) {
            scriptMovimentacao.DefinirDirecao(obj.ReadValue<Vector2>());
        }

        if (obj.action.name == controles.Jogador.ModoFotografia.name) {
            GameManager.instancia.AlterarModo();
        }

        if (obj.action.name == controles.Jogador.Olhar.name) {
            scriptCamera.AjustarPosicaoMouse(obj.ReadValue<Vector2>());
        }
    }

    private void Input_onActionCanceled(InputAction.CallbackContext obj) {
        
    }
}
