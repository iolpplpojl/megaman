using UnityEngine;

public class NPCBrain : MonoBehaviour
{
    public NPC npc;


    public void setUp()
    {
        if(npc is NPC_Shop)
        {
            //��ȭ �߰�
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

            Debug.Log("NPC�ν���!");
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

           Debug.Log("NPC�νĹ�������!");
        
    }
}
