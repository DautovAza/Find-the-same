using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private LabledSlider widthSlider;
    [SerializeField] private LabledSlider heightSlider;
    [SerializeField] private LabledSlider sameCardSlider;

    private void Awake()
    {
        Load();
    }

    public void Save()
    {
        Settings settings = new Settings
        {
            Width = widthSlider.Value,
            Height = heightSlider.Value,
            SameCardsCount = sameCardSlider.Value
        };
        SettingProvider.SaveFile(settings);
    }

    private void Load()
    {
        Settings settings = SettingProvider.LoadFile();

        widthSlider.Value = settings.Width;
        heightSlider.Value = settings.Height;
        sameCardSlider.Value = settings.SameCardsCount;
    }
}
