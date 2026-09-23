using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ImageMoviment : MonoBehaviour
{

    private RectTransform _rectTransform;
    private RectTransform _finalPoint;
    private float _velocity = 2;
    //public RectTransform PointCLickerFinal;
    [Header("Input Settings")]
    [SerializeField] private InputActionProperty _newInput;
    
    [Header("Slider Settings")]
    [SerializeField] private BarraStatus _aumentarBarra;

    public float Range = 180f;
    public float infor;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        //_finalPoint = GameObject.FindGameObjectWithTag("Ritmico").GetComponent<RectTransform>();
        _aumentarBarra = FindAnyObjectByType<BarraStatus>();
    }
    private void OnEnable() => _newInput.action.Enable();
    private void OnDisable() => _newInput.action.Disable();

    void Update()
    {
       MoveLeft();
       CalculateZone();
    }

    public void DefinirNovaDistancia(RectTransform novofinal, float vel)
    {
        _velocity = vel;
        _finalPoint = novofinal;
    }

    void CalculateZone()
    {
        float DistanceBegin = Vector2.Distance(_rectTransform.transform.position, _finalPoint.transform.position);
        
        infor = DistanceBegin;
        if (DistanceBegin <= Range) 
        {
            if (_newInput.action.WasPressedThisFrame())
            {
                StartCoroutine(Deactive());
            }
        }
    }

    private IEnumerator Deactive()
    {
        _aumentarBarra.Aumentarbarra();
        yield return null;
        ImageManeger.Instance.DesactivateObject(gameObject);
    }

    void MoveLeft() => _rectTransform.anchoredPosition += Vector2.left * _velocity * Time.deltaTime;
}
