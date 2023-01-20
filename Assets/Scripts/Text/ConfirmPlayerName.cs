using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmPlayerName : MonoBehaviour
{
    public Text NameBox;

    // Start is called before the first frame update
    void Start()
    {
        NameBox.text = PlayerPrefs.GetString("name");
    }

    public void ResetKeyName(string keyName)
    {
        PlayerPrefs.DeleteKey(keyName);
        SceneManager.LoadScene("Enter Name Scene");
    }

    public void Confirm()
    {
        SceneManager.LoadScene("Cave_01");
    }

}
