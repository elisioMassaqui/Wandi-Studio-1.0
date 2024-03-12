using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    public Button meuBotao;

    void Start()
    {
       
    }

    void Update(){
         if (meuBotao != null)
        {
            // Adiciona este script como um handler para o evento OnPointerUp do botão
            meuBotao.onClick.AddListener(OnPointerUp);

            // Agende a chamada automática do OnPointerUp após 10 segundos
            Invoke("ChamarOnPointerUp", 10f);
        }
    }

    void ChamarOnPointerUp()
    {
        OnPointerUp(); // Chama o método após 10 segundos
    }

    public void OnPointerUp()
    {
        Debug.Log("Botão específico foi liberado!");
        // Adicione aqui o código que deseja executar quando o botão específico for liberado.
    }
}
