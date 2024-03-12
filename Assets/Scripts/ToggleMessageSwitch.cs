using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMessageSwitch : MonoBehaviour
{
    public Toggle toggle1;
    public Toggle toggle2;
    public Text mensagemText;

    private void Start()
    {
       
    }

    // Método público para iniciar a rotina a partir do Inspector..
    public void IniciarRotinaMensagens()
    {
        StartCoroutine(AlternarMensagens());
    }

    IEnumerator AlternarMensagens()
    {
        while (true)
        {
            // Exibe mensagem para Toggle 1 por 3 segundos
            mensagemText.text = "Mensagem para Toggle 1";
            toggle1.isOn = true;
            toggle2.isOn = false;
            yield return new WaitForSeconds(3f);

            // Exibe mensagem para Toggle 2 por 3 segundos
            mensagemText.text = "Mensagem para Toggle 2";
            toggle1.isOn = false;
            toggle2.isOn = true;
            yield return new WaitForSeconds(3f);
        }
    }
}
