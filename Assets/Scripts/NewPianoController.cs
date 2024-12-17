using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class NewPianoController : MonoBehaviour
{
    public List<MusicData> allMusicData; 
    public TMP_Dropdown musicDropdown; 
    public Renderer[] renderer = new Renderer[49];

    private MusicData currentMusic; 
    private int currentNoteIndex = 0;
    public float highlightDuration = 0.5f; 
    private bool isPlaying = false; 
    private float songStartTime; 

    private void Start()
    {
       
        PopulateDropdown();

        musicDropdown.onValueChanged.AddListener(delegate { OnMusicSelectionChanged(); });

        currentMusic = null;
        currentNoteIndex = 0;
        isPlaying = false;
    }

    private void Update()
    {
        if (isPlaying && currentMusic != null && currentNoteIndex < currentMusic.noteTimes.Length)
        {
            float elapsedTime = Time.time - songStartTime;

            if (elapsedTime >= currentMusic.noteTimes[currentNoteIndex])
            {
                int noteIndex = currentMusic.noteIndexes[currentNoteIndex];
                HighlightKey(noteIndex );
                currentNoteIndex++;
            }
        }
    }

    private void HighlightKey(int noteIndex)
    {
        renderer[noteIndex].material.color = Color.yellow;

        StartCoroutine(RevertColorAfterDelay(noteIndex));
    }

    IEnumerator RevertColorAfterDelay(int noteIndex)
    {
        yield return new WaitForSeconds(highlightDuration);
        if(noteIndex>=0 && noteIndex<=28){
            renderer[noteIndex].material.color = Color.white;
        }
        else{
            renderer[noteIndex].material.color = Color.black;
        }
        
    }

    private void PopulateDropdown()
    {
        musicDropdown.options.Clear();

        musicDropdown.options.Add(new TMP_Dropdown.OptionData("Selecione uma música"));

        foreach (var music in allMusicData)
        {
            musicDropdown.options.Add(new TMP_Dropdown.OptionData(music.musicName));
        }

        musicDropdown.value = 0;
        musicDropdown.RefreshShownValue();
    }

    private void OnMusicSelectionChanged()
    {
        int selectedIndex = musicDropdown.value;

        if (selectedIndex == 0)
        {
            currentMusic = null;
            currentNoteIndex = 0;
            isPlaying = false;
            Debug.Log("Nenhuma música selecionada.");
            return;
        }

        selectedIndex -= 1;

        if (selectedIndex >= 0 && selectedIndex < allMusicData.Count)
        {
            LoadMusic(allMusicData[selectedIndex]);
            StartMusic();
        }
    }

    private void LoadMusic(MusicData newMusic)
    {
        currentMusic = newMusic;
        currentNoteIndex = 0;
        isPlaying = false; 
        Debug.Log($"Música carregada: {newMusic.musicName}");
    }

    private void StartMusic()
    {
        songStartTime = Time.time; 
        isPlaying = true;
        Debug.Log("Música iniciada.");
    }
}
