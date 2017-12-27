using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMenu : Menu
{
    enum MenuOptions { Fire, Heal}
    public Magic fire;
    public Magic heal;
 

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
            case MenuOptions.Fire:
                inputController.characterPointer.SetInitialTargetEnemy();
                break;
            case MenuOptions.Heal:
                inputController.characterPointer.SetInitialTargetPlayer();
                break;
        }
    }

    public override void RunMenuOption(int menuOptionIndex, Character target)
    {
        Player caster = inputController.playerInfo.owner;
        inputController.DisableMenu();

        switch ((MenuOptions)menuOptionIndex)
        {
            case MenuOptions.Fire:
                if (caster.HaveEnoughMana(fire.manaCost)) {
                    print("Use Fire on " + target.name);
                    caster.SpendMana(fire.manaCost);
                    fire.UseAction(target, inputController.playerInfo.owner);
                }
                break;
            case MenuOptions.Heal:
                if (caster.HaveEnoughMana(heal.manaCost))
                {
                    print("Use Heal on " + target.name);
                    caster.SpendMana(heal.manaCost);
                    heal.UseAction(target, inputController.playerInfo.owner);
                }
                break;
        }
    }


}
