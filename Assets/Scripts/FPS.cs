using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;

    private float _dt;
    private float _fps;
    
    private void Update()
    {
        _dt += (Time.deltaTime - _dt) * 0.1f;
        _fps = 1.0f / (_dt);
        fpsText.text = $"FPS: {Mathf.Ceil(_fps)}";
    }
}
