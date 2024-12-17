using UnityEngine;

[CreateAssetMenu(fileName = "NewMusicData", menuName = "Music Data", order = 1)]
public class MusicData : ScriptableObject
{
    public string musicName;
    public float[] noteTimes;
    public float[] endTimes;
    public int[] noteIndexes;
}
