using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public CursorController cursor;

    public PlayerInfoController playerInfo;

    public MoveChooserController moveChooser;
    public MagicMenu magicMenu;
    public ItemMenu itemMenu;
    public CharacterPointer characterPointer;
    public DamageVisualizer damageVisualizer;


    Menu activeMenu;

    void Awake() {
//        activeMenu = moveChooser;
       // ReturnToBaseMenu();
    }

    void Update() {
        if (IsPointingAtCharacters())
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                characterPointer.AdvancePointerBackward();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                characterPointer.AdvancePointerForward();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                // Select target
                activeMenu.RunMenuOption(cursor.GetCursorIndex(), characterPointer.GetTarget());
                characterPointer.DisablePointer();
                characterPointer.ResetCameraTransform();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Return to normal UI
                characterPointer.DisablePointer();
                characterPointer.ResetCameraTransform();
            }
        }
        else if(activeMenu != null)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                IncrementCursor();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                DecrementCursor();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                SelectMenuItem();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ReturnToBaseMenu();
            }
        }
    }

    void SelectMenuItem() {
        int cursorIndex = cursor.GetCursorIndex();
        activeMenu.SelectMenuItem(cursorIndex);
    }
    void IncrementCursor()
    {
        int cursorIndex = cursor.GetCursorIndex();
        Transform nextCursorItem = activeMenu.GetNextCursorItem(cursorIndex);
        cursor.SetCursorPosition(nextCursorItem);
    }
    void DecrementCursor()
    {
        int cursorIndex = cursor.GetCursorIndex();
        Transform prevCursorItem = activeMenu.GetPrevCursorItem(cursorIndex);
        cursor.SetCursorPosition(prevCursorItem);
    }
    public void ReturnToBaseMenu()
    {
        if(activeMenu != moveChooser)
            SwitchMenu(moveChooser);
    }
    public void SwitchMenu(Menu newMenu) {
        //cursor.PlaySound();
        if (activeMenu != null)
            activeMenu.ui.SetActive(false);
        newMenu.ui.gameObject.SetActive(true);
        activeMenu = newMenu;

        Transform nextCursorItem = activeMenu.GetNextCursorItem(-1);
        cursor.SetCursorPosition(nextCursorItem);
    }
    bool IsPointingAtCharacters() {
        return characterPointer.IsPointerActive();
    }
    public void DisableMenu()
    {
        activeMenu.ui.SetActive(false);
        activeMenu = null;
    }
}
