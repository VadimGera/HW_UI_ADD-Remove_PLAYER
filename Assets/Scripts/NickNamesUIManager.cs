using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NickNamesUIManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab; // Префаб игрока (для создания новых игроков)
    [SerializeField] private Transform nicknamesParent; // Родительский объект для хранения UI-элементов ников
    [SerializeField] private TextMeshProUGUI nicknameTextPrefab; // Префаб UI-элемента ника

    private Dictionary<GameObject, TextMeshProUGUI> nicknames = new Dictionary<GameObject, TextMeshProUGUI>();

    public void AddPlayer()
    {
        GameObject newPlayer = Instantiate(playerPrefab);
        // Генерируем случайное имя для игрока
        string randomName = GenerateRandomName();
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
            GameObject playerInstance = nicknames[player].gameObject;
            Destroy(nicknames[player].gameObject);
            nicknames.Remove(player);
            Destroy(playerInstance);
        }
    }

    private string GenerateRandomName()
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string name = "";

        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, alphabet.Length);
            char randomChar = alphabet[randomIndex];
            name += randomChar;
        }

        return name;
    }
}