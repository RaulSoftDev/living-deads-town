using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWritter : MonoBehaviour
{
    private static TextWritter instance;

    private List<TextWritterSingle> textWritterSingleList;

    private void Awake()
    {
        instance = this;
        textWritterSingleList = new List<TextWritterSingle>();
    }

    public static TextWritterSingle AddWritter_Static(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWritter(uiText, textToWrite, timePerCharacter, invisibleCharacters);
    }

    private TextWritterSingle AddWritter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        TextWritterSingle textWritterSingle = new TextWritterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters);
        textWritterSingleList.Add(textWritterSingle);
        return textWritterSingle;
    }

    public static void RemoveWritter_Static(Text uiText)
    {
        instance.RemoveWriter(uiText);
    }

    private void RemoveWriter(Text uiText)
    {
        for (int i = 0; i < textWritterSingleList.Count; i++)
        {
            if(textWritterSingleList[i].GetUIText() == uiText)
            {
                textWritterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        Debug.Log(textWritterSingleList.Count);
        for (int i = 0; i < textWritterSingleList.Count; i++)
        {
            bool destroyInstance = textWritterSingleList[i].Update();
            if (destroyInstance)
            {
                textWritterSingleList.RemoveAt(i);
                i--;
            }
        }
    }



}

/*
 * Represents a single TextWritter instance
 * */
public class TextWritterSingle
{
    private Text uiText;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;
    private bool invisibleCharacters;

    public TextWritterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;
    }

    public bool Update()
    {
            timer -= Time.deltaTime;
            while (timer <= 0)
            {
                //Display next character
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</Color>";
                }
                uiText.text = text;

                if (characterIndex >= textToWrite.Length)
                {
                    //Entire string displayed
                    uiText = null;
                    return true;
                }
            }

        return false;
    }

    public Text GetUIText()
    {
        return uiText;
    }

    public bool IsActive()
    {
        return characterIndex < textToWrite.Length;
    }

    public void WriteAllAndDestroy()
    {
        uiText.text = textToWrite;
        characterIndex = textToWrite.Length;
        TextWritter.RemoveWritter_Static(uiText);
    }
}
