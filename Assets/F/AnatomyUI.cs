using UnityEngine;
using UnityEngine.UI;

public class AnatomyUI : MonoBehaviour
{
    public Button nextButton;
    public AnatomyScenario scenario;

    void Start()
    {
        if (nextButton != null && scenario != null)
        {
            nextButton.onClick.AddListener(scenario.NextStep);
        }
    }
}
