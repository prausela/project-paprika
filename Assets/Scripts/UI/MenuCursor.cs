using UnityEngine;

namespace UI
{
    public class MenuCursor : MonoBehaviour
    {
        public void ShowCursor()
        {
            gameObject.SetActive(true);
        }

        public void HideCursor()
        {
            gameObject.SetActive(false);
        }

    }
}
