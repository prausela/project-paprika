using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEffectController : MonoBehaviour, IListenable
    {
        #region IListenable_Properties
        
        public AudioClip AudioClip => _audioClip;
        private AudioClip _audioClip;

        public AudioSource AudioSource => _audioSource;
        private AudioSource _audioSource;
        
        #endregion

        #region IListenable_Methods

        public void InitAudioSource()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioClip = AudioSource.clip;
        }

        public void PlayOnShot(AudioClip audioClip) => AudioSource.PlayOneShot(audioClip);

        public void Play() => AudioSource.Play();

        public void Stop() => AudioSource.Stop();

        #endregion

        #region Unity_Events

        void Start()
        {
            InitAudioSource();
        }

        #endregion
        
    }
}
