using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChooserController : Menu {

    enum MenuOptions {Attack, Magic, Item, Defend}

    public override Transform GetNextCursorItem(int currentIndex) {
        int nextIndex = (currentIndex + 1) % menuChoices.Length;
        Transform nextMenuChoice = menuChoices[nextIndex];
        if (nextIndex == (int)MenuOptions.Defend)
        {
            ActionDetails.ActionDescription(inputController.playerInfo.owner.defendAction.description);
        }
        else
        {
            ActionDetails.ResetDetails();
        }
        return nextMenuChoice;
    }

    public override Transform GetPrevCursorItem(int currentIndex)
    {
        int nextIndex = currentIndex - 1;
        if (nextIndex < 0)
            nextIndex = menuChoices.Length - 1;
        Transform prevMenuChoice = menuChoices[nextIndex];
        if (nextIndex == (int)MenuOptions.Defend)
        {
            ActionDetails.ActionDescription(inputController.playerInfo.owner.defendAction.description);
        }
        else
        {
            ActionDetails.ResetDetails();
        }
        return prevMenuChoice;
    }

    public override void SelectMenuItem(int currentIndex) {
        switch ((MenuOptions)currentIndex)
        {
            case MenuOptions.Attack:
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
                owner.basicAttack.UseAction(target, owner);
                break;
            case MenuOptions.Defend:
                owner.Defend();
                break;
        }

    }

}
