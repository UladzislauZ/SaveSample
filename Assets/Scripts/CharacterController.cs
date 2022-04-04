using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private Text message;
    [SerializeField] private Text secondMessage;
    
    public CharacterModel model;
    
    void Start()
    {
        model = new CharacterModel();
    }

    void Update()
    {
        scoreLabel.text = model.Score().ToString();
        transform.Translate(0, 0, Input.GetAxis("Vertical") * model.SpeedMove() * Time.deltaTime);
        transform.Rotate(0,Input.GetAxis("Horizontal") * model.SpeedRotate() * Time.deltaTime,0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            message.text = "Click RBM for get";
            if (Input.GetMouseButtonDown(0))
            {
                model.AddScore(other.gameObject.GetComponent<Stone>().Damage(model.DamageAxe()));
                Debug.Log(model.Score());
            }
        }

        if (other.gameObject.layer == 9)
        {
            message.text = "Click E for UpgradeAxe or Click R for UpgradeLevel";
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (model.Buy(100 * model.Level()))
                {
                    model.UpgradeAxe();
                    secondMessage.text = "Axe upgraded";
                }
                else
                {
                    secondMessage.text = "Not enough money";
                }
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (model.Buy(50 * model.Level()))
                {
                    model.UpgradeLevel();
                    secondMessage.text = "Level upgraded";
                }
                else
                {
                    secondMessage.text = "Not enough money";
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        message.text = "";
        secondMessage.text = "";
    }
}
