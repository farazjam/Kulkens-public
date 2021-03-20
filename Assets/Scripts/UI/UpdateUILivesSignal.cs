using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUILivesSignal 
{
    public UpdateUILivesSignal(string livesText)
    {
        LivesText = livesText;
    }
    public string LivesText { get; }
}
