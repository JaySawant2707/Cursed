using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public void TriggerFightP1()
    {
        FindAnyObjectByType<Wizard>().fire = true;
    }

    public void TriggerFightP2()
    {
        FindAnyObjectByType<Wizard>().fireInterval = .5f;
    }

    public void StopFight()
    {
        FindAnyObjectByType<Wizard>().fire = false;
    }
}
