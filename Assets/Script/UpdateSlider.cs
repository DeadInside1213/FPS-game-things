using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSlider : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI text;
    [SerializeField] private Slider Slider;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = Slider.value.ToString();
    }
}
