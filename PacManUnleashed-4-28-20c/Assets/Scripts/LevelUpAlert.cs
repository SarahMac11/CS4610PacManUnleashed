using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpAlert : MonoBehaviour
{
    public TextMeshProUGUI levelUpText;

    void Start()
    {
        levelUpText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelUp.newLevelUpdate)
        {
            StartCoroutine(ShowMessage("LEVEL UP", 5));
            //            LevelUp.newLevelUpdate = false;
        }
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        levelUpText.text = message;
        levelUpText.enabled = true;    // show text
        yield return new WaitForSeconds(5);    // show text as active for 5 seconds
        levelUpText.enabled = true;
        LevelUp.newLevelUpdate = false;
    }
}
