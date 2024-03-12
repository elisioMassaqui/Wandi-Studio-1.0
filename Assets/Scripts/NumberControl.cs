using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberControl : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button aumentarButton;
    public Button diminuirButton;

    private float valor;

    private void Start()
    {
        // Adicione ouvintes aos botões
        aumentarButton.onClick.AddListener(AumentarValor);
        diminuirButton.onClick.AddListener(DiminuirValor);
        // Adicione um ouvinte de mudança de valor ao InputField
        inputField.onValueChanged.AddListener(AtualizarValor);
    }

    public void AumentarValor()
    {
        // Aumente o valor e mantenha dentro do intervalo de 0 a 180
        valor = Mathf.Clamp(valor + 1, 0f, 180f);
        AtualizarUI();
    }

    public void DiminuirValor()
    {
        // Diminua o valor e mantenha dentro do intervalo de 0 a 180
        valor = Mathf.Clamp(valor - 1, 0f, 180f);
        AtualizarUI();
    }

    private void AtualizarValor(string novoValor)
    {
        // Converta o valor de string para float e mantenha dentro do intervalo de 0 a 180
        valor = Mathf.Clamp(float.Parse(novoValor), 0f, 180f);
        AtualizarUI();
    }

    private void AtualizarUI()
    {
        // Atualize o texto do InputField
        inputField.text = valor.ToString();
        // Faça aqui qualquer outra ação desejada com o valor, como enviar para outro script ou objeto.
    }
}
