using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player
{
    [SerializeField] private Deck deck;
    [SerializeField] private PlayerMode playerMode;
    public string name;
    private int team;

    public Deck GetDeck => deck;
    public void SetDeck(Deck deck) => this.deck = deck;
    public PlayerMode GetPlayerMode => playerMode;
    public void SetPlayerMode(PlayerMode mode) => playerMode = mode;
    public int GetTeam => team;
    public void SetTeam(int team) => this.team = team;

    public Player(string name, int team){
        this.name = name;
        this.team = team;
        playerMode = PlayerMode.None;
    }
}

public enum PlayerMode
{
    MovingPiece,
    SelectingPiece,
    None
}
