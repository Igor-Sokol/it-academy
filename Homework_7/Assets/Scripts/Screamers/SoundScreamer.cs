using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundScreamer : Screamer
{
    private AudioSource _audioSource;
    private float _timer;

    [SerializeField] private AudioClip[] clips;

    public AudioSource AudioSource { get { return _audioSource = _audioSource ?? GetComponent<AudioSource>(); } }

    private void Start()
    {
        AudioSource.clip = clips[Random.Range(0, clips.Length)];
        _timer = AudioSource.clip.length;
        AudioSource.Play();
    }
    
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Hide();
        }
    }
}
