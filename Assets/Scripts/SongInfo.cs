using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongInfo : MonoBehaviour, ISaveable
{
    public int _songID;
    public string _SongTitle;
    public string _SongAuthor;
    public string _FileName;
    public int _highScore;
    public int _plays;
    public string _stars;
    public int _totalNote;
    public int _notesHit;
    public float _songCompletionPercentage;
    public string _Difficulty;

    public void LoadFromSaveData(PersistentDataInformation a_SaveData)
    {
        foreach (PersistentDataInformation.SongData mySongData in a_SaveData.m_SongList)
        {
            Debug.Log("=-=-=-=-==-=--=-=-=--=" + mySongData.m_SongTitle);
            if (mySongData.m_songID == _songID)
            {
                _SongTitle = mySongData.m_SongTitle;
                _SongAuthor = mySongData.m_SongAuthor;
                _Difficulty = mySongData.m_FileName;
                _highScore = mySongData.m_highScore;
                _plays = mySongData.m_plays;
                _stars = mySongData.m_stars;
                _totalNote = mySongData.m_totalNote;
                _notesHit = mySongData.m_notesHit;
                _songCompletionPercentage = mySongData.m_songCompletionPercentage;
                _songID = mySongData.m_songID;
                _Difficulty = mySongData._Difficulty;
                break;
            }
        }

    }

    public void PopulateSaveData(PersistentDataInformation a_SaveData)
    {
        PersistentDataInformation.SongData mySongData = new PersistentDataInformation.SongData();
        mySongData.m_songID = _songID;
        mySongData.m_SongTitle = _SongTitle;
        mySongData.m_SongAuthor = _SongAuthor;
        mySongData.m_FileName = _FileName;
        mySongData.m_highScore = _highScore;
        mySongData.m_plays = _plays;
        mySongData.m_stars = _stars;
        mySongData.m_totalNote = _totalNote;
        mySongData.m_notesHit = _notesHit;
        mySongData.m_songCompletionPercentage = _songCompletionPercentage;
        mySongData._Difficulty = _Difficulty;

        Debug.Log("Adding: " + mySongData.m_SongTitle);
        a_SaveData.m_SongList.Add(mySongData);
    }

    
}
