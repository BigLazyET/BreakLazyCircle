
using UnityEngine;

namespace BreakLazyCircle.Util
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        [Header("音高范围")]
        public float lowPitchRange = 0.95f;
        public float highPitchRange = 1.05f;

        public AudioSource sfxAudioSource;

        private void Awake()
        {
            Instance ??= this;
        }

        /// <summary>
        /// 利用全局或给定的AudioSource播放给定的音效，或其中之一的音效
        /// </summary>
        /// <param name="volume"></param>
        /// <param name="audioSource"></param>
        /// <param name="randomPitch"></param>
        /// <param name="audioClips"></param>
        public void PlayOneShotSound(float volume = 1.0f, AudioSource audioSource = null, bool randomPitch = false, params AudioClip[] audioClips)
        {
            if (audioClips.Length == 0)
                return;
            var specificAudioSource = audioSource ?? sfxAudioSource;

            var audioClipIndex = Random.Range(0, audioClips.Length);
            var pitch = randomPitch ? Random.Range(lowPitchRange, highPitchRange) : 1.0f;

            specificAudioSource.pitch = pitch;
            specificAudioSource.PlayOneShot(audioClips[audioClipIndex], volume);
        }

        /// <summary>
        /// 新建对象且附加AudioSource组件，然后播放，结束并销毁
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="position"></param>
        /// <param name="volume"></param>
        public void PlaySoundAtLocation(AudioClip clip, Vector3 position, float volume = 1.0f)
        {
            if (clip == null) return;

            var tempAudioSource = new GameObject("TempAudio");
            tempAudioSource.transform.position = position;
            var src = tempAudioSource.AddComponent<AudioSource>();
            src.clip = clip;
            src.volume = volume;
            src.spatialBlend = 1.0f;
            src.rolloffMode = AudioRolloffMode.Linear;
            src.minDistance = 5.0f;
            src.maxDistance = 15.0f;
            src.dopplerLevel = 0;
            tempAudioSource.AddComponent<Disposable>().Lifetime = clip.length;
            src.Play();
        }
    }
}
