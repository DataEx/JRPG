using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMenu : Menu
{
    enum MenuOptions { Cyclone, Holy}
    public Magic cyclone;
    public Magic holy;
 

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
            case MenuOptions.Cyclone:
                inputController.characterPointer.SetInitialTargetEnemy();
                break;
            case MenuOptions.Holy:
                inputController.characterPointer.SetInitialTargetEnemy();
                break;
        }
    }

    public override void RunMenuOption(int menuOptionIndex, Character target)
    {
        Player caster = inputController.playerInfo.owner;
        inputController.DisableMenu();

        switch ((MenuOptions)menuOptionIndex)
        {
            case MenuOptions.Cyclone:
                if (caster.HaveEnoughMana(cyclone.manaCost)) {
                    print("Use Fire on " + target.name);
                    caster.SpendMana(cyclone.manaCost);
                    cyclone.UseAction(target, inputController.playerInfo.owner);
                }
                break;
            case MenuOptions.Holy:
                if (caster.HaveEnoughMana(holy.manaCost))
                {
                    print("Use Heal on " + target.name);
                    caster.SpendMana(holy.manaCost);
                    holy.UseAction(target, inputController.playerInfo.owner);
                }
                break;
        }
    }


}
