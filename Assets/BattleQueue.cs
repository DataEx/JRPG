using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleQueue : MonoBehaviour {
    static Queue<Character> queue;
    public List<Player> publicPlayers;
    public List<Enemy> publicEnemies;
    public static List<Player> players;
    public static List<Enemy> enemies;

    void Awake() {
        enemies = publicEnemies;
        players = publicPlayers;

        queue = new Queue<Character>();
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

    public static void Pop() {
        if (queue.Count > 0)
        {
            if (players.Count == 0)
            {
                print("Game Over!");
                return;
            }
            if (enemies.Count == 0)
            {
                print("Victory!");
                return;
            }

            Character activeCharacter = queue.Dequeue();
            activeCharacter.StartTurn();
            queue.Enqueue(activeCharacter);
        }
    }

    public static void RemoveCharacter(Character character)
    {
        if (character.GetType() == typeof(Player)) {
            players.Remove((Player)character);
        }
        else if (character.GetType() == typeof(Enemy)) {
            enemies.Remove((Enemy)character);
        }
    }
}
