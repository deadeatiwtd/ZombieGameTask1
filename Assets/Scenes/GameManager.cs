using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject[] zombies;
    public Vector3 selectedSize;
    public Vector3 pushForce;
    private InputAction next, prev, jump;
    private int selectedIndex = 0;
    public TMP_Text timerText;
    private float timer;

    private void Start()
    {
        next = InputSystem.actions.FindAction("NextZombie");
        prev = InputSystem.actions.FindAction("PrevZombie");
        jump = InputSystem.actions.FindAction("Jump");
        SelectedZombie(selectedIndex);
    }

    void SelectedZombie(int index)
    {
        if (selectedZombie != null)
        {
            selectedZombie.transform.localScale = Vector3.one;
        }
        selectedZombie = zombies[index];
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("selected: " + selectedZombie);
    }
    private void Update()
    {
        if (next.WasPressedThisFrame())
        {
            Debug.Log("next");
            selectedIndex++;
            if (selectedIndex >= zombies.Length)
                selectedIndex = 0;
            SelectedZombie(selectedIndex);
        }

        if (prev.WasPressedThisFrame())
        {
            Debug.Log("prev");
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = zombies.Length - 1;
            SelectedZombie(selectedIndex);
        }

        if (jump.WasPressedThisFrame())
        {
            Debug.Log("Jump");
            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            if(rb != null)
                rb.AddForce(pushForce);
                
        }
        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("F1");
        
    }
}  

    

