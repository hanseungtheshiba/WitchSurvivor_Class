using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Player CurrentPlayer { get; private set; }
    public List<Skill> skillList;

    private void Awake()
    {
        CurrentPlayer = FindObjectOfType<Player>();
    }
}
