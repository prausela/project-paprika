using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class MenuButton : Button
    {
        public MenuCursor MenuCursor => _menuCursor;
        [SerializeField] private MenuCursor _menuCursor;

        public override void OnSelect(BaseEventData baseEventData)
        {
            base.OnSelect(baseEventData);
            _menuCursor.ShowCursor();
        }

        public override void OnDeselect(BaseEventData baseEventData)
        {
            base.OnDeselect(baseEventData);
            _menuCursor.HideCursor();
        }
    }
}
