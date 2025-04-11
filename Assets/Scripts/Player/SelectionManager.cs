using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
//using UnityEngine.UI;
using TMPro;
//using TMPro.EditorUtilities;

[System.Serializable]
public class SelectionInfo
{
    public string displayName;
    public Sprite selectionSprite;
    public RuntimeAnimatorController controller;
}

public class SelectionManager : MonoBehaviour
{
    public RuntimeAnimatorController controller;
    public SpriteRenderer sr;
    //public List<Sprite> characters = new List<Sprite>();
   // public List<RuntimeAnimatorController> runtimeAnimators = new List<RuntimeAnimatorController>();
    public List<SelectionInfo> selections = new List<SelectionInfo>();
    private int selectedCharacter = 0;
    public Animator playercharacter;
    public TMP_Text nameText;

    private void Start()
    {
        sr.sprite = selections[selectedCharacter].selectionSprite;
        nameText.text = selections[selectedCharacter].displayName;
    }

    public void NextOption()
    {
        selectedCharacter++;

        /*
        selectedCharacter = selectedCharacter + 1;
        if (selectedCharacter == characters.Count)
        {
            selectedCharacter = 0;
        }
        sr.sprite = characters[selectedCharacter];
        */
        UpdateUI();
    }

    public void BackOption()
    {
        /*
        selectedCharacter = selectedCharacter - 1;
        if (selectedCharacter < 0)
        {
            selectedCharacter = characters.Count;
        }
        sr.sprite = characters[selectedCharacter];
        */
        selectedCharacter--;
        UpdateUI();
    }

    void UpdateUI()
    {
        selectedCharacter = (int)Mathf.Repeat(selectedCharacter, selections.Count);
        sr.sprite = selections[selectedCharacter].selectionSprite;
        nameText.text = selections[selectedCharacter].displayName;
    }

    public void ConfirmSelection()
    {
        playercharacter.runtimeAnimatorController = selections[selectedCharacter].controller;   
    }
    /*
    public void PlayGame()
    {
        //PrefabUtility.SaveAsPrefabAsset(playercharacter, "Assets/Players/Male/Idle/playercharacter.prefab");
        //SceneManager.LoadScene("Level_One");
    }
    */
}
