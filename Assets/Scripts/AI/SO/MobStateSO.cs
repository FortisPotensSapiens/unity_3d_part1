using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMobState", menuName = "Survival/MobStats")]
public class MobStateSO : ScriptableObject
{
    public Vector2 MaxStayTimeBorders;
    public float FollowRange;
    public float AttackRange;
    public float Power;
    public float MaxHealth;
}
