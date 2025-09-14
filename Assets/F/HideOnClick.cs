using UnityEngine;

public class HideOnClick : MonoBehaviour
{
    public GameObject innerPart; // يلي لازم يبين لما هاي تختفي

    public void OnSelect()
    {
        gameObject.SetActive(false);  // أخفي هاي العضلة
        if (innerPart != null) innerPart.SetActive(true);
    }
}
