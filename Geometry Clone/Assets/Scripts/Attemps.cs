using UnityEngine;
using UnityEngine.UI;
public class Attemps : MonoBehaviour
{

    #region PublicStuff
    public Text attemps;
    #endregion

    #region PrivateStuff
    private Player player;
    #endregion

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    void Update()
    {
        attemps.text = "Attemp: " + player.attemps;
    }

    #region Methods
    #endregion
}
