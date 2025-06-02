using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;    
    public List<QuestProgress> now_quest;

    void Start(){
        instance = this;
        EnemyHealth.DeathSignal += EnemyDeath;
    }

    public void EnemyDeath(int id){
        Debug.Log(string.Format("{0}번 적 사망!",id));

        foreach (QuestProgress progress in now_quest)
        {
            if(progress.questData.require.req == Require.EnemyDie)
            {
                if(progress.questData.require.id == id)
                {
                    progress.currentAmount++;
                    if(progress.questData.require.needamount == progress.currentAmount)
                    {
                        Debug.Log("퀘스트 완료!");
                        progress.isCompleted = true;
                    }
                }
            }
        }
    }

    public void QuestClear(){
        //...
    }
    public void QuestStart(Quest quest)
    {
        Debug.Log("퀘스트 시작!");
        QuestProgress a = new QuestProgress(quest);
        now_quest.Add(a);
    }
}

[System.Serializable] // 세이브 로드를 위해 직렬화 가능하게
public class QuestProgress
{
    public Quest questData; // 참조하는 QuestData (어떤 퀘스트인지)
    public int currentAmount;   // 현재 진행도 (플레이어별로 다름)
    public bool isCompleted;    // 완료 여부

    public QuestProgress(Quest data) {
        questData = data;
        currentAmount = 0;
        isCompleted = false;
    }
}



public enum Require{
    EnemyDie,
    Collect
}

