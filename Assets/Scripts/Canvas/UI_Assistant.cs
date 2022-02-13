using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Assistant : MonoBehaviour
{
    private Text messageText;
    private TextWritterSingle textWritterSingle;
    public string[] messageArray;
    public string firsttext;
    public int currentPosition;

    private void Awake()
    {
        messageText = transform.Find("Conversations").Find("Text").GetComponent<Text>();

        currentPosition = -1;
        transform.Find("Conversations").GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (textWritterSingle != null && textWritterSingle.IsActive())
            {
                //Currently active TextWriter
                textWritterSingle.WriteAllAndDestroy();
            }
            else
            {
                /*messageArray = new string[]
                         {
             "Este es el asistente de habla, hola y adios, nos vemos la próxima vez",
             "¡Hola, aquí!",
             "Este es un efecto realmente curioso y útil",
             "Aprendamos a hacer código y sacar grandes juegos",
             "Busca Battle Royal Tycoon en Steam",
                         };*/

                currentPosition++;
                textWritterSingle = TextWritter.AddWritter_Static(messageText, messageArray[currentPosition], 0.05f, true, true);

            }
        };

            
    }
 
    void Start()
    {
        BeginTalk();
    }

    private void Update()
    {
        Debug.Log("Current = " + currentPosition + "Actual = " + messageArray.Length);
    }

    void BeginTalk()
    {
        if (textWritterSingle != null && textWritterSingle.IsActive())
        {
            //Currently active TextWriter
            textWritterSingle.WriteAllAndDestroy();
        }
        else
        {
            textWritterSingle = TextWritter.AddWritter_Static(messageText, firsttext, 0.05f, true, true);
        }
    }
}
