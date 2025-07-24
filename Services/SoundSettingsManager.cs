using UnityEngine;
using UnityEngine.Audio;

namespace JamKit {
    public class SoundSettingsManager : IService {
        
        public float MusicVolume { get; private set; } = 1f;
        public float SfxVolume { get; private set; } = 1f;

        private const string MUSIC_VOLUME_PLAYER_PREF_NAME = "MusicVolume";
        private const string SFX_VOLUME_PLAYER_PREF_NAME = "SfxVolume";

        private AudioMixer _audioMixer;
        
        public SoundSettingsManager(AudioMixer audioMixer) {
            _audioMixer = audioMixer;
        }
        
        public void Initialize() {
            LoadFromPlayerPrefs();
        }

        public float GetVolumeByType(VolumeType volumeType) {
            switch (volumeType) {
                case VolumeType.Music: return MusicVolume;
                case VolumeType.Sfx: return SfxVolume;
            }
            return 0f;
        }

        public void SetValueByType(VolumeType volumeType, float value) {
            switch (volumeType) {
                case VolumeType.Music: SerMusicVolume(value); break;
                case VolumeType.Sfx: SetSfxVolume(value); break;
            }
        }

        private void SerMusicVolume(float volume) {
            MusicVolume = volume;
            PlayerPrefs.SetFloat(MUSIC_VOLUME_PLAYER_PREF_NAME, volume);
            _audioMixer.SetFloat(MUSIC_VOLUME_PLAYER_PREF_NAME, Mathf.Log10(volume) * 20);
            PlayerPrefs.Save();
        }

        private void SetSfxVolume(float volume) {
            SfxVolume = volume;
            PlayerPrefs.SetFloat(SFX_VOLUME_PLAYER_PREF_NAME, volume);
            _audioMixer.SetFloat(SFX_VOLUME_PLAYER_PREF_NAME, Mathf.Log10(volume) * 20);
            PlayerPrefs.Save();
        }

        private void LoadFromPlayerPrefs() {
            MusicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_PLAYER_PREF_NAME, 1.0f);
            SfxVolume = PlayerPrefs.GetFloat(SFX_VOLUME_PLAYER_PREF_NAME, 1.0f);
        }
    }
}