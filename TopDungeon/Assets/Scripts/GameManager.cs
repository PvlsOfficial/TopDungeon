using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //PlayerPrefs.DeleteAll(); //delete all saved data

        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;
    //public GameObject weapon...
    public FloatingTextManager floatingTextManager;

    //Logic
    public int money = 0;
    public int xp = 0;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //save State

    //int preferedSkin
    //int money
    //int xp
    //int weaponLevel
    public void SaveState()
    {
        Debug.Log("Saving...");
        string s = "";
        s += "0" + "|";
        s += money.ToString() + "|";
        s += xp.ToString() + "|";
        s += "0";
        PlayerPrefs.SetString("saveState", s);
        Debug.Log("Saved!");
    }

    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("saveState"))
        {
            return;
        }
        Debug.Log("Loading...");
        string[] data = PlayerPrefs.GetString("saveState").Split('|');
        //int preferedSkin = int.Parse(data[0]);
        money = int.Parse(data[1]);
        xp = int.Parse(data[2]);
        //int weaponLevel = int.Parse(data[3]);
        Debug.Log("Loaded!");
    }
}
