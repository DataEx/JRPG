using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleQueue : MonoBehaviour {
    static Queue<Character> queue;
    public List<Player> publicPlayers;
    public List<Enemy> publicEnemies;
    public static List<Player> players;
    public static List<Enemy> enemies;
    static List<Character> charactersToDelete;
    public static BattleQueue instance;

    void Awake() {
        instance = this;

        enemies = publicEnemies;
        players = publicPlayers;

        queue = new Queue<Character>();

        charactersToDelete = new List<Character>();

        foreach (Player player in players)
        {
            queue.Enqueue(player);
        }
        foreach (Enemy enemy in enemies)
        {
            queue.Enqueue(enemy);
        }

        Pop();
    }

    public static void ResetState()
    {
        ActionDetails.ResetDetails();
        InputController.staticCharacterPointer.ResetCameraTransform();
        if(instance)
            instance.Invoke("Pop", 1.5f);
    }


    void Pop() {
        foreach (Character c in charactersToDelete)
        {
            RemoveCharacter(c);
        }
        charactersToDelete.Clear();

        if (queue.Count > 0)
        {
            if (players.Count == 0)
            {
                ActionDetails.GameOverDisplayDetails();
                // Fade out 
                return;
            }
            if (enemies.Count == 0)
            {
                ActionDetails.VictoryDisplayDetails();
                foreach (Player p in players) {
                    p.AnimateCharacter(Character.CharacterPoses.Victory);
                }
                // Player dances
                // fade out
                return;
            }

            Character activeCharacter = queue.Dequeue();
            while (activeCharacter == null)
            {
                activeCharacter = queue.Dequeue();
            }
            queue.Enqueue(activeCharacter);
            activeCharacter.StartTurn();
        }
    }

    public static void SetToRemoveCharacter(Character character)
    {
        charactersToDelete.Add(character);
    }
    static void RemoveCharacter(Character character)
    {
        if (character.GetType() == typeof(Player)) {
            players.Remove((Player)character);
        }
        else if (character.GetType() == typeof(Enemy)) {
            enemies.Remove((Enemy)character);
        }
        DestroyImmediate(character.gameObject);
    }
}
