using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SelectionManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> characters = new List<Sprite>();
    private int selectedCharacter = 0;
    public GameObject playercharacter;

    public void NextOption()
    {
        selectedCharacter = selectedCharacter + 1;
        if (selectedCharacter == characters.Count)
        {
            selectedCharacter = 0;
        }
        sr.sprite = characters[selectedCharacter];
    }

/*    public void BackOption()
    {
        selectedCharacter = selectedCharacter - 1;
        if (selectedCharacter < 0)
        {
            selectedCharacter = characters.Count;
        }
        sr.sprite = characters[selectedCharacter];
    }*/

    public void PlayGame()
    {
        PrefabUtility.SaveAsPrefabAsset(playercharacter, "Assets/Players/Male/Idle/playercharacter.prefab");
        SceneManager.LoadScene("Level_One");
    }
}
