using TMPro;
using UnityEngine;

public class Info : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;
    [SerializeField] private TextMeshProUGUI versionText;

    [SerializeField] private string version = "v1.0.4";
    
    private float _dt;
    private float _fps;

    private void Awake()
    {
        versionText.text = version;
    }

    private void Update()
    {
        _dt += (Time.deltaTime - _dt) * 0.1f;
        _fps = 1.0f / (_dt);
        fpsText.text = $"FPS: {Mathf.Ceil(_fps)}";
    }
}
