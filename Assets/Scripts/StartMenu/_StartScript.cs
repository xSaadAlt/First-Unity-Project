using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class _StartScript : MonoBehaviour,IPointerClickHandler
{

public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("_Level1");
    }

}
