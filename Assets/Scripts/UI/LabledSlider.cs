using UnityEngine;
using UnityEngine.UI;

public class LabledSlider : MonoBehaviour
{
    [SerializeField] private string lableString;
    [SerializeField, Min(1)] private int minValue;
    [SerializeField, Min(2)] private int maxValue;
    [SerializeField] private Text lableText;
    [SerializeField] private Text numText;
    [SerializeField] private Slider slider;

    public int Value
    {
        get { return Mathf.RoundToInt(slider.value); }
        set 
        { 
            slider.value = value;
            numText.text = value.ToString();
        }
    }

    private void Awake()
    {
        if (lableText)
        {
            lableText.text = lableString;
        }

        if (slider)
        {
            slider.wholeNumbers = true;
            slider.minValue = minValue;
            slider.maxValue = maxValue;
            slider.onValueChanged.AddListener((value) => numText.text = value.ToString());
        }
    }
}
