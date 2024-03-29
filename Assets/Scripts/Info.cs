using TMPro;
using UnityEngine;

public class Info : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;
    [SerializeField] private TextMeshProUGUI versionText;

    private readonly string _version = "v1.0.7";
    
    private float _dt;
    private float _fps;

    private void Awake()
    {
        versionText.text = _version;
    }

    private void Update()
    {
        _dt += (Time.deltaTime - _dt) * 0.1f;
        _fps = 1.0f / (_dt);
        fpsText.text = $"FPS: {Mathf.Ceil(_fps)}";
    }
}
