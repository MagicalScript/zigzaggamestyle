using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GameData : MonoBehaviour
{
    Vector3 theScale;

    public float TimePerLevel = 30.0f;
    private float CurrentTimeLevel = 0f;
    string _COIN = "coin";
    string _LEVEL = "level";
    string _PLAYER_ID = "playerid";
    string _AVGSPEED = "avgspeed";
    private float _avgspeed;
    public float AvgSpeed
    {
        get
        {
            _avgspeed = PlayerPrefs.GetFloat(_AVGSPEED);
            return _avgspeed;
        }
        set
        {
            _avgspeed = value;
            PlayerPrefs.SetFloat(_AVGSPEED, _avgspeed);
        }
    }

    // public int coin;
    private int _coin;
    public int coin
    {
        get { return _coin; }
        set
        {
            _coin = value;
            coins.SetText(_coin.ToString());
        }
    }
    private int _level = 1;
    public int level
    {
        get { return _level; }
        set
        {
            _level = value;
            currentLevel.SetText(_level.ToString());
            nextLevel.SetText((_level + 1).ToString());
        }
    }
    void Start()
    {
        theScale = progressBar.transform.localScale;
        this.loadData();

    }
    void Update()
    {
        CurrentTimeLevel += Time.deltaTime;
        if (CurrentTimeLevel > TimePerLevel)
        {
            level += 1;
            CurrentTimeLevel = 0;
            this.saveData();
        }
        theScale.x = (CurrentTimeLevel / TimePerLevel);
        progressBar.transform.localScale = theScale;
    }



    public TextMeshProUGUI currentLevel;
    public TextMeshProUGUI nextLevel;
    public TextMeshProUGUI coins;
    public GameObject progressBar;

    public characterProperties SelecteCharacter;

    public List<characterProperties> Characters;

    public void saveData()
    {
        PlayerPrefs.SetInt(_COIN, coin);
        PlayerPrefs.SetInt(_LEVEL, level);
        PlayerPrefs.SetInt(_PLAYER_ID, SelecteCharacter.id);
    }

    public void loadData()
    {
        coin = PlayerPrefs.GetInt(_COIN);
        level = PlayerPrefs.GetInt(_LEVEL);
        Debug.Log("level : " + level);
        loadPlayerCharacter();
    }

    public void loadPlayerCharacter()
    {
        int _id = 0;
        _id = PlayerPrefs.GetInt(_PLAYER_ID);
        var charct = from item in Characters
                     where item.id == _id
                     select item;
        SelecteCharacter = charct.ElementAt(0);
    }

}
