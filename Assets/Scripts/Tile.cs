using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private GameObject hightlight;
    [SerializeField] private GameObject piece;
    private bool possibleMove = false;
    private bool covered = false;
    private bool possibleCapture = false;
    private PlayerManager playerManager;
    private GameManager gameManager;

    public GameObject GetPiece() => piece;
    public void RemovePiece() => piece = null;
    public bool Covered => covered;
    public void Start(){
        playerManager = FindObjectOfType<PlayerManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Init(bool isOffset){
        GetComponent<Renderer>().material.color = isOffset ? offsetColor : baseColor;
    }

    public void AddPiece(GameObject piece){
        this.piece = piece;
        piece.transform.position = transform.position;
        piece.GetComponent<Piece>().SetTile(this);
    }

    public Vector2 GetVectorPosition(int xChange, int yChange){
        return new Vector2(Mathf.Ceil(transform.position.x + xChange), Mathf.Ceil(transform.position.y + yChange));
    }
    public void KillPiece()
    {
        Destroy(piece);
        RemovePiece();
    }

    /// <summary>
    /// Determines if the tile can be moved to based on the presence and team of the piece.
    /// </summary>
    /// <returns>
    /// 1 if the tile can be moved to with no piece, 2 if the tile can be moved to with a piece of a different team, and 0 otherwise.
    /// </returns>;
    public int CanMoveTo(Piece piece){
        if (this.piece == null){
            return 1;
        }else{
            if (this.piece.GetComponent<Piece>().GetTeam != piece.GetTeam){
                return 2;        
            }
        }
        return 0;
    }

    public void PossibleMove(){
        transform.Find("PossibleMove").gameObject.SetActive(true);
        possibleMove = true;
    }

    public void CoveredTile(){
        transform.Find("Covered").gameObject.SetActive(true);
        covered = true;
    }

    public void PossibleCapture(){
        if (piece.GetComponent<KingPiece>() == null){
            transform.Find("Capture").gameObject.SetActive(true);
            possibleCapture = true;
        }else{
            transform.Find("Capture").gameObject.SetActive(true);
        }
    }

    public void ResetTile(){
        transform.Find("PossibleMove").gameObject.SetActive(false);
        transform.Find("Covered").gameObject.SetActive(false);
        transform.Find("Capture").gameObject.SetActive(false);
        possibleMove = false;
        covered = false;
        possibleCapture = false;
    }

    #region Player ineraction
        void OnMouseEnter() {
            hightlight.SetActive(true);
        }

        void OnMouseExit() {
            hightlight.SetActive(false);
        }

        private void OnMouseDown()
        {
            if (playerManager.GetPlayerMode != PlayerMode.MovingPiece){
                //Selecting piece
                if (piece != null) { 
                    if (piece.GetComponent<Piece>().GetTeam == gameManager.turnOff){
                        playerManager.SelectTile(this);
                        playerManager.SwitchPlayerMode(PlayerMode.MovingPiece); 
                        piece.GetComponent<Piece>().PossibleMoves(MoveCheckType.Move);
                    }

                }
            } else if (playerManager.GetPlayerMode == PlayerMode.MovingPiece && piece != null){
                if (piece.GetComponent<Piece>().GetTeam == gameManager.turnOff){
                    //Select new piece
                    playerManager.DeselectPiece();
                    playerManager.SelectTile(this);
                    playerManager.SwitchPlayerMode(PlayerMode.MovingPiece);
                    piece.GetComponent<Piece>().PossibleMoves(MoveCheckType.Move);
                }else{
                    if (possibleCapture)
                    {
                        //Moving to tile with enemy piece
                        //Making sure its a diffrent tile and movement is allowed
                        KillPiece();
                        playerManager.MovePiece(gameObject);
                        gameManager.NextTurn();
                    }
                }
            } else {
                    if (playerManager.GetTile != this || playerManager.GetTile != null){
                        if (possibleMove){
                            //Moving to tile
                            //Making sure its a diffrent tile and movement is allowed
                            playerManager.MovePiece(gameObject);
                            gameManager.NextTurn();
                        }
                    }
                }
            }
    #endregion
}
