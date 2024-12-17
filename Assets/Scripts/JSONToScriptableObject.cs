using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MusicDataLoader : MonoBehaviour
{
    public MusicData musicData; 
    public string jsonFilePath = "Assets/Resources/FurElise.json"; // 

    void Start()
    {
        LoadMusicDataFromJson();
    }

    public void LoadMusicDataFromJson()
    {
        if (File.Exists(jsonFilePath))
        {
            string jsonContent = File.ReadAllText(jsonFilePath);
            MusicDataJson jsonData = JsonUtility.FromJson<MusicDataJson>(jsonContent);

           
            musicData.musicName = jsonData.musicName;
            musicData.noteTimes = jsonData.noteTimes;
            musicData.endTimes = jsonData.endTimes;
            musicData.noteIndexes = jsonData.noteIndexes;

            Debug.Log("MusicData preenchido com sucesso!");

#if UNITY_EDITOR
            EditorUtility.SetDirty(musicData); 
            AssetDatabase.SaveAssets();        
#endif
        }
        else
        {
            Debug.LogError($"Arquivo JSON não encontrado em: {jsonFilePath}");
        }
    }

    [System.Serializable]
    private class MusicDataJson
    {
        public string musicName;
        public float[] noteTimes;
        public float[] endTimes;
        public int[] noteIndexes;
    }
}
