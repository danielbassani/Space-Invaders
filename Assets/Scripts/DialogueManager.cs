using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public GameObject panel;
    public GameObject bombSpawner;
    public string[] text;

    private Text currentText;
    private int currentIndex;
    private int length;
    private int level;
    private bool isBombSpawnerActive;

    // Start is called before the first frame update
    void Start()
    {
        //initialize current and length
        currentIndex = 0;
        length = text.Length;

        //check if bomb spawner is supposed to be active in this scene
        isBombSpawnerActive = bombSpawner.activeSelf;

        //enable dialogue UI if he has something to say
        if(length > 0)
        {
            dialogueUI.SetActive(true);
            panel.SetActive(true);
            bombSpawner.SetActive(false);

            //pause game until dialogue is done
            Time.timeScale = 0f;

            //initialize level
            level = SceneManager.GetActiveScene().buildIndex;

            //initialize currentText
            currentText = dialogueUI.GetComponentInChildren<Image>().GetComponentInChildren<Text>();
            currentText.text = text[0];
        }
    }

    public void ScrollText()
    {
        if(currentIndex < length - 1)
        {
            currentIndex++;
            currentText.text = text[currentIndex];
        }else if(currentIndex == length - 1)
        {
            dialogueUI.SetActive(false);
            panel.SetActive(false);

            //re-enable bomb spawner if it was active before
            if (isBombSpawnerActive)
            {
                bombSpawner.SetActive(true);
            }
            Time.timeScale = 1f;
        }
    }
}
