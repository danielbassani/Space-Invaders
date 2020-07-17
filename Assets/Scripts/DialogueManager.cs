using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public GameObject panel;
    public string[] text;

    private Text currentText;
    private int currentIndex;
    private int length;
    private int level;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(true);
        panel.SetActive(true);

        //pause game until dialogue is done
        Time.timeScale = 0f;

        //initialize level
        level = SceneManager.GetActiveScene().buildIndex;

        //initialize currentText
        currentText = dialogueUI.GetComponentInChildren<Image>().GetComponentInChildren<Text>();
        currentText.text = text[0];

        //initialize current and length
        currentIndex = 0;
        length = text.Length;
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
            Time.timeScale = 1f;
        }
    }
}
