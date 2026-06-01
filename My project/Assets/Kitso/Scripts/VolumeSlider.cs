using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

void Start()
    {
    if (!PlayerPrefs.HasKey("Volume"))
    {
        PlayerPrefs.SetFloat("Volume", 1f);
         Load();
        }
    else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        AudioListener.volume = volumeSlider.value;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }

}

