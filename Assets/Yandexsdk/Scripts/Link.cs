using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    //По кнопке
    public void GotoDeveloperPage()
    {
        //if(Language.isRusLang)
        //    Application.OpenURL("https://yandex.ru/games/developer?name=DemiGames");
        //else Application.OpenURL("https://yandex.com/games/developer?name=DemiGames");

        Application.OpenURL("https://yandex.ru/games/developer?name=DemiGames");
    }
}
