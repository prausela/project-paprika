using UnityEngine;

namespace Controllers
{
    public interface IListenable
    {
        AudioClip AudioClip { get; }
        AudioSource AudioSource { get; }

        void InitAudioSource();
        void PlayOnShot(AudioClip audioClip);
        void Play();
        void Stop();
    }
}
