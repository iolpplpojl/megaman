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

    public void StartDialogue()
    {
        DialogueSystem.instance.SetDialogue(npc);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        var o = collision.gameObject.GetComponent<PlayerAttack>();
        o.NpcOn = this;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var o = collision.gameObject.GetComponent<PlayerAttack>();
        o.NpcOn = null;
        
    }
}
