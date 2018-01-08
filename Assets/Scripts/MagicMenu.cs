using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicMenu : Menu
{
    public Text[] manaCostTexts;
    enum MenuOptions { Cyclone, Holy}
    public Magic cyclone;
    public Magic holy;

    public Color greyColor;
    public Color blackColor;

    public override void Awake()
    {
        base.Awake();
        manaCostTexts[0].text = cyclone.manaCost.ToString() + " MP";
        manaCostTexts[1].text = holy.manaCost.ToString() + " MP";
    }
    void Start() {
        Player player = inputController.playerInfo.owner;

        if (player.HaveEnoughMana(cyclone.manaCost))
        {
            menuChoices[0].GetComponent<Text>().color = blackColor;
            manaCostTexts[0].color = blackColor;
        }
        else
        {
            menuChoices[0].GetComponent<Text>().color = greyColor;
            manaCostTexts[0].color = greyColor;
        }

        if (player.HaveEnoughMana(holy.manaCost))
        {
            menuChoices[1].GetComponent<Text>().color = blackColor;
            manaCostTexts[1].color = blackColor;
        }
        else
        {
            menuChoices[1].GetComponent<Text>().color = greyColor;
            manaCostTexts[1].color = greyColor;
        }

    }


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
        Player caster = inputController.playerInfo.owner;
        switch ((MenuOptions)currentIndex)
        {
            case MenuOptions.Cyclone:
                if (caster.HaveEnoughMana(cyclone.manaCost)) {
                    inputController.characterPointer.SetInitialTargetEnemy();
                }
                break;
            case MenuOptions.Holy:
                if (caster.HaveEnoughMana(holy.manaCost))
                {
                    inputController.characterPointer.SetInitialTargetEnemy();
                }
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
                caster.SpendMana(cyclone.manaCost);
                cyclone.UseAction(target, inputController.playerInfo.owner);
                break;
            case MenuOptions.Holy:
                caster.SpendMana(holy.manaCost);
                holy.UseAction(target, inputController.playerInfo.owner);
                break;
        }
    }


}
