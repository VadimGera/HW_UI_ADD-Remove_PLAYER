using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NickNamesUIManager : MonoBehaviour
{
    [SerializeField] public GameObject playerPrefab; // Префаб игрока (для создания новых игроков)
    [SerializeField] public Transform nicknamesParent; // Родительский объект для хранения UI-элементов ников
    [SerializeField] public TextMeshProUGUI nicknameTextPrefab; // Префаб UI-элемента ника

    private Dictionary<GameObject, TextMeshProUGUI> nicknames = new Dictionary<GameObject, TextMeshProUGUI>();

    public void AddPlayer()
    {
        GameObject newPlayer = Instantiate(playerPrefab);
        // Генерируем случайное имя для игрока
        string randomName = "Player" + Random.Range(100, 1000);
        newPlayer.name = randomName;
        
        // Создаем UI-элемент ника и связываем его с игроком
        TextMeshProUGUI nicknameText = Instantiate(nicknameTextPrefab, nicknamesParent);
        nicknameText.text = randomName;
        nicknames.Add(newPlayer, nicknameText);
    }

    public void RemovePlayer(GameObject player)
    {
        if (nicknames.ContainsKey(player))
        {
            TextMeshProUGUI nicknameText = nicknames[player];
            nicknames.Remove(player);
            Destroy(nicknameText.gameObject);
            Destroy(player);
        }
    }
}