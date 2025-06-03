using UnityEngine;

public class NPCBrain : MonoBehaviour
{
    public NPC npc;


    public void setUp()
    {
        if(npc is NPC_Shop)
        {
            //대화 추가
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

            Debug.Log("NPC인식중!");
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

           Debug.Log("NPC인식범위나감!");
        
    }
}
