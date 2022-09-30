using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class SettingProvider 
{
    private const string fileName = "settings.json";
    private static string directory => Application.dataPath + "/Resources/";

    public static Settings LoadFile()
    {
        try
        {
            using (var reader = new StreamReader(directory+ fileName))
            {
                string json = reader.ReadToEnd();
                return JsonUtility.FromJson<Settings>(json);
            }
        }
        catch
        {
            Debug.Log("�� ������� ��������� ���� ��������! ������ �����");

            return new Settings()
            {
                Width = 4,
                Height = 4,
                SameCardsCount = 2
            };
        }
        

    }

    public static void SaveFile(Settings settings)
    {
        string json = JsonUtility.ToJson(settings);

        using (var writer = new StreamWriter(directory + fileName))
        {
            writer.Write(json);
        }
        Debug.Log("���� �������� � " + directory + fileName);
    }
}
