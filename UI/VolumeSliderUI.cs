using UnityEngine;
using UnityEngine.UI;

namespace JamKit {
    public class VolumeSliderUI : MonoBehaviour {

        
        public VolumeType volumeType;
        public Slider slider;

        private void Start() {
            var settings = ServiceLocator.Get<SoundSettingsManager>();
            slider.value = settings.GetVolumeByType(volumeType);
            slider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        private void OnSliderValueChanged(float value) {
            var settings = ServiceLocator.Get<SoundSettingsManager>();
            settings.SetValueByType(volumeType, value);
        }
    }
}