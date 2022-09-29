using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightScreamer : Screamer
{
    private Light _light;
    private float _timer;

    [SerializeField] private float duration;
    [SerializeField] private float minIntensity;
    [SerializeField] private float maxIntensity;

    private Light Light { get { return _light = _light ?? GetComponent<Light>(); } }

    private void Update()
    {
        Light.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time / duration, 1));
        
        _timer += Time.deltaTime;
        if (_timer >= duration)
        {
            Hide();
        }
    }
}
