using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILives : MonoBehaviour
{
    [SerializeField] private Text _livesText;
    public void ChangeLives(string livesText)
    {
        _livesText.text = livesText;
    }
}
