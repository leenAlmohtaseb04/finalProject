using UnityEngine;

public class AnatomyLayers : MonoBehaviour
{
    [Header("Layers")]
    public GameObject humanLayer;   // الجسم الخارجي
    public GameObject muscleLayer;  // العضلات

    // إظهار الجسم فقط
    public void ShowHuman()
    {
        if (humanLayer != null) humanLayer.SetActive(true);
        if (muscleLayer != null) muscleLayer.SetActive(false);
    }

    // إظهار العضلات فقط
    public void ShowMuscles()
    {
        if (humanLayer != null) humanLayer.SetActive(false);
        if (muscleLayer != null) muscleLayer.SetActive(true);
    }
}
