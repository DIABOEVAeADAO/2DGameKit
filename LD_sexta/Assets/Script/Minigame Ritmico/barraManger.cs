using UnityEngine;
using UnityEngine.UI;

public class BarraStatus : MonoBehaviour
{
    public Image imagemBarra;
    public float valorMaximo = 100f;
    private float defaultValue;
    [Range(0,1)] public float Diminuir;
    [Range(0, 1)] public float Aumentar;
    



    void Start()
    {
        defaultValue = valorMaximo;
    }

    public void DiminuirBarra()
    {
        Debug.Log("carlos");
        if (defaultValue > 0)
        {
            defaultValue -= Time.deltaTime * Diminuir;
            imagemBarra.fillAmount = defaultValue / valorMaximo; //
            Debug.Log("salve");
        }
    }

    public void Aumentarbarra()
    {
        imagemBarra.fillAmount += Aumentar; //
    }
}
