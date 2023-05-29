using UnityEngine;

public class CoderAnimations : MonoBehaviour
{
    [SerializeField] GameObject _runParticle;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void SpawnParticle()
    {
        PlayPop();
        Instantiate(_runParticle, transform.position, Quaternion.identity);
    }

    private void PlayPop()
    {
        if (!_audio.isPlaying)
        {
            _audio.Play();
        }
    }
}
