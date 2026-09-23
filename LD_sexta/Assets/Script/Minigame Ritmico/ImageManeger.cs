using UnityEngine;

public class ImageManeger : MonoBehaviour
{
    [Header(" Image Generator")]
    public GameObject Images;
    [SerializeField] private int QuantidadeDeImagens;

    [Header("Spanw Settings")]
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private RectTransform _parent;
    public static ImageManeger Instance { get; set; }
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
    }
    
    private void Start()
    {
        for(int i = 0; i < QuantidadeDeImagens; i++)
        {
            GameObject G = Instantiate(Images,_parent);
            ObjectPool.Instance.SetPool(G);
            G.SetActive(false);
        }
    }

    // Escolher qual spawn será
    //

    #region Envio e recebimento do objeto
    public void ActiviteObject()
    {
        GameObject gameObject = ObjectPool.Instance.GetPool();
        
        gameObject.GetComponent<RectTransform>().anchoredPosition = _rectTransform.anchoredPosition;
        gameObject.GetComponent<RectTransform>().rotation = _rectTransform.rotation;
        gameObject.SetActive(true);
        //Ativar objeto
    }

    public void DesactivateObject(GameObject gameObject)
    {
        //mandar objeto de volta
        ObjectPool.Instance.SetPool(gameObject);
        //desativar o objeto
        gameObject.SetActive(false);
        ActiviteObject();
    }
    #endregion
}
