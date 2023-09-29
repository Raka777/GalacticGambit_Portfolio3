using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class interactionMenu : MonoBehaviour
{
    [SerializeField] TMP_Text interactionText;

    public void updateInteractionText(string value)
    {
        interactionText.text = value;
    }
}
