using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
//НЕВЕРОЯТНО ПЛОХО
public class MoneyManager : MonoBehaviour
{
    [SerializeField] int moneyCount;
    int maxMoneyCount;
    int moneyOnRun;
    int runsCount = 1;
    [SerializeField] TextMeshProUGUI moneyTextField;
    [SerializeField] TextMeshProUGUI startGameText;
    [SerializeField] GameObject FinalMenu;
    string continueGameText = "Продолжить", newGameText = "Новая игра";
    float timeToShowPanel = 1.5f;
    List<CoinController> coinControllers = new List<CoinController>();

    [SerializeField] SpawnManager spawnManager;
    [SerializeField] NavigationController navigationController;
    private void Awake()
    {
        coinControllers = FindObjectsOfType<CoinController>().ToList();
        foreach (var coinController in coinControllers)
            moneyOnRun += coinController.GetMoneyForCollect();
        maxMoneyCount += runsCount * moneyOnRun;
    }
    void Start()
    {
        FinalMenu.SetActive(false);
        ChangeStartGameText();
        UpdateMoneyText();            
    }

    public void UpdateMoneyCount(int difference)
    {
        moneyCount += difference;
        UpdateMoneyText();
        if(moneyCount >= maxMoneyCount) 
        {
            StartCoroutine(ShowFInalMenu());
        }
        ChangeStartGameText();
    }

    public void UpdateMoneyText()
    {
        string tempText = moneyCount + "/" + maxMoneyCount;
        moneyTextField.text = tempText;
    }

    public int GetMoneyCount()
    {
        return moneyCount;
    }

    void ChangeStartGameText()
    {
        if (moneyCount > 0)
            startGameText.text = continueGameText;
        else startGameText.text = newGameText;
    }

    IEnumerator ShowFInalMenu()
    {
        yield return new WaitForSeconds(timeToShowPanel);
        navigationController.EnableCharacterControl(false);
        FinalMenu.SetActive(true);
    }
    //По кнопке
    public void AnotherRun()
    {
        runsCount++;
        maxMoneyCount = (runsCount * moneyOnRun);
        spawnManager.UpdatePointNumber(0);
        spawnManager.RespawnPlayer();
        FinalMenu.SetActive(false);
        ResetCoins();
        UpdateMoneyText();
        navigationController.EnableCharacterControl(true);
    }

    void ResetCoins()
    {
        foreach (var coinObject in coinControllers)
        {
            coinObject.isCoinCollect = false;
            coinObject.ResetCoin();
        }
    }
}
