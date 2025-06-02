using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public List<Quest> quest;

    void Start(){
        Enemy.DeathSignal += EnemyDeath;
    }

    public void EnemyDeath(int id){
        foreach(var q in quest){
            if(q.require.req == Require.EnemyDie){
                if(q.require.id == id){
                    q.require.nowamount++;
                    if(q.require.needamount == q.require.needamount){
                        QuestClear();
                    }
                }
            }
        }
    }

    public void QuestClear(){
        //...
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


public class Quest : ScriptableObject{
    int questId;
    QuestRequire require;
}

public class QuestRequire : ScriptableObject{
    public Require req;
    public int id;
    public int needamount;
}
public enum Require{
    EnemyDie,
    Collect
}

