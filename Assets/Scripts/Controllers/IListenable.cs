using UnityEngine;

namespace Controllers
{
    public interface IListenable
    {
        AudioClip AudioClip { get; }
        AudioSource AudioSource { get; }

        void InitAudioSource();
        void PlayOnShot();
        void Play();
        void Stop();
    }
}
