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
    int moneyOnRun = 300;
    int runsCount = 1;
    [SerializeField] TextMeshProUGUI moneyTextField;
    [SerializeField] TextMeshProUGUI startGameText;
    [SerializeField] GameObject finalMenu;
    string continueGameText, newGameText;
    string ruContinueText = "Продолжить", ruNewGameText = "Новая игра";
    string enContinueText = "Continue", enNewGameText = "New game";
    float timeToShowPanel = 1.5f;

    [SerializeField] SpawnManager spawnManager;
    [SerializeField] NavigationController navigationController;
    [SerializeField] CoinsCollectionController coinsCollectionController;
    [SerializeField] InputGame inputGame;
    SoundController soundController;
    private void Awake()
    {
        soundController = FindObjectOfType<SoundController>();
        if (Language.isRusLang)
        {
            continueGameText = ruContinueText;
            newGameText = ruNewGameText;
        } 
        else
        {
            continueGameText = enContinueText;
            newGameText = enNewGameText;
        }
    }
    void Start()
    {
        runsCount = Progress.Instance.playerInfo.runsCount;
        moneyCount = Progress.Instance.playerInfo.moneyCount;
        maxMoneyCount = runsCount * moneyOnRun;
        finalMenu.SetActive(false);
        ChangeStartGameText();
        UpdateMoneyText();      
        

    }

    public void UpdateMoneyCount(int difference)
    {
        moneyCount += difference;
        UpdateMoneyText();
        if(moneyCount >= maxMoneyCount) 
        {
            StartCoroutine(ShowFinalMenu());
        }
        ChangeStartGameText();

        Progress.Instance.playerInfo.moneyCount = moneyCount;
        YandexSDK.Save();
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

    IEnumerator ShowFinalMenu()
    {
        soundController.Play("WinGame");
        yield return new WaitForSeconds(timeToShowPanel);
        navigationController.EnableCharacterControl(false);
        inputGame.ShowCursorState(true);
        finalMenu.SetActive(true);
    }
    //По кнопке
    public void AnotherRun()
    {
        runsCount++;       
        maxMoneyCount = (runsCount * moneyOnRun);
        spawnManager.UpdatePointNumber(0);
        spawnManager.RespawnPlayer();
        finalMenu.SetActive(false);
        inputGame.ShowCursorState(false);
        coinsCollectionController.ResetCoins();
        UpdateMoneyText();
        navigationController.EnableCharacterControl(true);

        Progress.Instance.playerInfo.runsCount = runsCount;
        YandexSDK.Save();
    }
}
