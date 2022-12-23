using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMgr : MonoBehaviour
{
    public static SaveMgr Instance;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            if(Instance!=this)
            {
                Destroy(gameObject);
                return;
            }
        }
    }

    [ContextMenu("清除最高分数")]
    public void ClearHighestScore()
    {
        PlayerPrefs.DeleteKey("HighestScore");
    }

    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("HighestScore", score);
        PlayerPrefs.Save();
    }

    public int GetHighestScore()
    {
        return PlayerPrefs.GetInt("HighestScore");
    }
}
