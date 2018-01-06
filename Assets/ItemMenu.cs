using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : Menu {
    enum MenuOptions { Potion, Ether}
    public Item potion;
    public Item ether;

    public override Transform GetNextCursorItem(int currentIndex)
    {
        int nextIndex = (currentIndex + 1) % menuChoices.Length;
        Transform nextMenuChoice = menuChoices[nextIndex];
        if (nextIndex == 0)
        {
            if (potion.description != "")
            {
                ActionDetails.ActionDescription(potion.description);
            }
        }
        else
        {
            if (ether.description != "") {
                ActionDetails.ActionDescription(ether.description);
            }
        }
        return nextMenuChoice;
    }

    public override Transform GetPrevCursorItem(int currentIndex)
    {
        int nextIndex = currentIndex - 1;
        if (nextIndex < 0)
            nextIndex = menuChoices.Length - 1;
        Transform prevMenuChoice = menuChoices[nextIndex];
        return prevMenuChoice;
    }

    public override void SelectMenuItem(int currentIndex)
    {
        switch ((MenuOptions)currentIndex)
        {
            case MenuOptions.Potion:
                inputController.characterPointer.SetInitialTargetPlayer();
                break;
            case MenuOptions.Ether:
                inputController.characterPointer.SetInitialTargetPlayer();
                break;
        }
    }

    public override void RunMenuOption(int menuOptionIndex, Character target)
    {
        inputController.DisableMenu();

        switch ((MenuOptions)menuOptionIndex)
        {
            case MenuOptions.Potion:
                potion.UseAction(target, inputController.playerInfo.owner);
                break;
            case MenuOptions.Ether:
                ether.UseAction(target, inputController.playerInfo.owner);
                break;
        }
    }


}
