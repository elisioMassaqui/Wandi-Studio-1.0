using UnityEngine;
using UnityEngine.UI;

public class robotController : MonoBehaviour
{
    public GameObject J2;
    public float velocityJ2 = 30f;
    public Slider sliderVelocityJ2;
    public float limiteSuperior = 380f; // Ajuste conforme necessário
    public float limiteInferior = 0f;
    public float grauDaRotacao = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        velocityJ2 = sliderVelocityJ2.value;

        // Verifica se a tecla Alpha1 está sendo pressionada.
        if (Input.GetKey(KeyCode.Alpha1))
        {
            // Rotação contínua enquanto a tecla está pressionada
            grauDaRotacao = J2.transform.rotation.eulerAngles.z + velocityJ2 * Time.deltaTime;

            // Aplica limites à rotação
            grauDaRotacao = Mathf.Clamp(grauDaRotacao, limiteInferior, limiteSuperior);

            // Verifica se a rotação está dentro dos limites
            if (grauDaRotacao >= limiteInferior && grauDaRotacao <= limiteSuperior)
            {   
                // Aplica a transformação apenas se estiver dentro dos limites
                J2.transform.localRotation = Quaternion.Euler(0, 0, grauDaRotacao);          

                // Exibe o grau de rotação no console (você pode ajustar isso conforme necessário)
                Debug.Log("Grau de Rotação: " + grauDaRotacao);

                //Calcular limites, (Opcional)...
                var calculaLlimite = limiteInferior - limiteSuperior;
                Debug.Log("Limites Calculado" + calculaLlimite);

            }
            else
            {
                Debug.Log("Fora dos limites de rotação!");
            }
        }
    }
}
