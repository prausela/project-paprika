using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEffectController : MonoBehaviour, IListenable
    {
        #region IListenable_Properties
        
        public AudioClip AudioClip => _audioClip;
        [SerializeField] private AudioClip _audioClip;

        public AudioSource AudioSource => _audioSource;
        private AudioSource _audioSource;
        
        #endregion

        #region IListenable_Methods

        public void InitAudioSource()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = AudioClip;
        }

        public void PlayOnShot() => AudioSource.PlayOneShot(AudioClip);

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
