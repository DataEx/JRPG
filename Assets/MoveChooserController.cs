using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChooserController : Menu {

    enum MenuOptions {Attack, Magic, Item, Defend}

    public override Transform GetNextCursorItem(int currentIndex) {
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

    public override void SelectMenuItem(int currentIndex) {
        switch ((MenuOptions)currentIndex)
        {
            case MenuOptions.Attack:
                print("Select Attack Target");
                inputController.characterPointer.SetInitialTargetEnemy();
                break;
            case MenuOptions.Magic:
                inputController.SwitchMenu(inputController.magicMenu);
                break;
            case MenuOptions.Item:
                inputController.SwitchMenu(inputController.itemMenu);
                break;
            case MenuOptions.Defend:
                RunMenuOption((int)MenuOptions.Defend, inputController.playerInfo.owner);
                break;
        }
    }

    public override void RunMenuOption(int menuOptionIndex, Character target)
    {
        Player owner = inputController.playerInfo.owner;
        inputController.DisableMenu();
        switch ((MenuOptions)menuOptionIndex)
        {
            case MenuOptions.Attack:
                print("Attack " + target.name);
                owner.basicAttack.UseAction(target, owner);
                break;
            case MenuOptions.Defend:
                print("Defending");
                owner.Defend();
                break;
        }

    }

}
