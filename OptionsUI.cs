using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour {

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private MusicManager musicManager;

    private TextMeshProUGUI soundVolumeText;
    private TextMeshProUGUI musicVolumeText;

    private void Awake() {
        soundVolumeText = transform.Find("soundVolumeText").GetComponent<TextMeshProUGUI>();
        musicVolumeText = transform.Find("musicVolumeText").GetComponent<TextMeshProUGUI>();
        transform.Find("soundIncreaseBtn").GetComponent<Button>().onClick.AddListener(() => {
            soundManager.IncreaseVolume();
            UpdateText();
        });
        transform.Find("soundDecreaseBtn").GetComponent<Button>().onClick.AddListener(() => {
            soundManager.DecreaseVolume();
            UpdateText();
        });
        transform.Find("musicIncreaseBtn").GetComponent<Button>().onClick.AddListener(() => {
            musicManager.IncreaseVolume();
            UpdateText();
        });
        transform.Find("musicDecreaseBtn").GetComponent<Button>().onClick.AddListener(() => {
            musicManager.DecreaseVolume();
            UpdateText();
        });
        transform.Find("mainMenuBtn").GetComponent<Button>().onClick.AddListener(() => {
            Time.timeScale = 1f;
            GameSceneManager.Load(GameSceneManager.Scene.MainMenuScene);
        });

    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            ToggleVisible();
        }
    }

    private void Start() {
        UpdateText();
        gameObject.SetActive(false);
    }

    private void UpdateText() {
        soundVolumeText.SetText(Mathf.RoundToInt(soundManager.GetVolume()*10).ToString());
        musicVolumeText.SetText(Mathf.RoundToInt(musicManager.GetVolume()*10).ToString());
    }
    public void ToggleVisible() {
        gameObject.SetActive(!gameObject.activeSelf);

        if(gameObject.activeSelf) {
            Time.timeScale = 0F;
        }
        else {
            Time.timeScale = 1f;
        }
    }

}
