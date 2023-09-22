using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenusController : MonoBehaviour
{
    [SerializeField] GameObject[] menus;
    void Start()
    {
        foreach (var menu in menus)
        {
            menu.SetActive(false);
        }
        menus[0].SetActive(true);
    }

}
