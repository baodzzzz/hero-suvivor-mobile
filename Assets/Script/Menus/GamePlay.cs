using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public void HandlePauseButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.Pause);
    }
}
