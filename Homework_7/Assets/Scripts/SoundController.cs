using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    private AudioSource _audioSource;
    private int _clipIndex;
    
    [SerializeField] private AudioClip[] clips;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        Play(_clipIndex);

        if (_clipIndex + 1 >= clips.Length)
        {
            _clipIndex = 0;
        }
        else
        {
            _clipIndex++;
        }
    }
    
    private void Play(int index)
    {
        if (index >= clips.Length || index < 0) return;

        _audioSource.clip = clips[index];
        _audioSource.Play();
    }
}
