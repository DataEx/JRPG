using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public Transform[] menuChoices;
    public InputController inputController;
    public virtual Transform GetNextCursorItem(int currentIndex) { return null; }
    public virtual Transform GetPrevCursorItem(int currentIndex) { return null; }
    public virtual void SelectMenuItem(int currentIndex) { }
    public virtual void RunMenuOption(int menuOptionIndex, Character target) {}
    public GameObject ui;

}
