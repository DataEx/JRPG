using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : Menu {
    enum MenuOptions { Potion, Ether, Grenade}
    public Item potion;
    public Item ether;
    public Item grenade;

    public override Transform GetNextCursorItem(int currentIndex)
    {
        int nextIndex = (currentIndex + 1) % menuChoices.Length;
        Transform nextMenuChoice = menuChoices[nextIndex];
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
            case MenuOptions.Grenade:
                inputController.characterPointer.SetInitialTargetEnemy();
                break;
        }
    }

    public override void RunMenuOption(int menuOptionIndex, Character target)
    {
        inputController.DisableMenu();

        switch ((MenuOptions)menuOptionIndex)
        {
            case MenuOptions.Potion:
                print("Use Potion on " + target.name);
                potion.UseAction(target, inputController.playerInfo.owner);
                break;
            case MenuOptions.Ether:
                print("Use Ether on " + target.name);
                ether.UseAction(target, inputController.playerInfo.owner);
                break;
            case MenuOptions.Grenade:
                print("Use Grenade on " + target.name);
                grenade.UseAction(target, inputController.playerInfo.owner);
                break;
        }
    }


}
