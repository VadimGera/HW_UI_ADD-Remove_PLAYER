using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class NickNamesUI : MonoBehaviour
{
    [SerializeField] public GameObject nicknameLabelPrefab; 
    private Dictionary<string, GameObject> nicknames = new Dictionary<string, GameObject>();

    public void AddPlayer(string playerName)
    {
        // Создайте новый UI лейбл для игрока
        GameObject nicknameLabel = Instantiate(nicknameLabelPrefab, transform);
        Text labelComponent = nicknameLabel.GetComponent<Text>();

        // Назначьте имя игрока для UI лейбла
        labelComponent.text = playerName;

        // Добавьте связь между именем игрока и его UI лейблом в словарь
        nicknames.Add(playerName, nicknameLabel);
    }

    public void RemovePlayer(string playerName)
    {
        // Проверьте, есть ли игрок в словаре
        if (nicknames.ContainsKey(playerName))
        {
            // Удалите UI лейбл из словаря и сцены
            Destroy(nicknames[playerName]);
            nicknames.Remove(playerName);
        }
    }
}