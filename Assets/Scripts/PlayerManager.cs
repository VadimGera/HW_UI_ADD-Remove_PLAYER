using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private NickNamesUI nickNamesUI;

    public void AddPlayer()
    {
        // Создайте новый игровой объект для игрока
        GameObject player = new GameObject("Player");

        // Получите ссылку на компонент Player
        Player playerComponent = player.AddComponent<Player>();

        // Установите имя игрока
        playerComponent.playerName = "Имя игрока";

        // Вызовите метод добавления игрока в NickNamesUI
        nickNamesUI.AddPlayer(playerComponent.playerName);
    }

    public void RemovePlayer(GameObject player)
    {
        // Вызовите метод удаления игрока из NickNamesUI
        nickNamesUI.RemovePlayer(player.GetComponent<Player>().playerName);
        Destroy(player);
    }
}
