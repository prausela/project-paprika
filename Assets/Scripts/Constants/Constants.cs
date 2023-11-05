using System.Collections.Generic;
using UnityEngine;

public static class Constants {
    public static readonly Dictionary<TileArrow, List<Arrow>> arrowKeyCombinations = new Dictionary<TileArrow, List<Arrow>> {
        {TileArrow.UP, new List<Arrow> { Arrow.UP }},
        {TileArrow.UP_RIGHT, new List<Arrow> { Arrow.UP, Arrow.RIGHT }},
        {TileArrow.UP_LEFT, new List<Arrow> { Arrow.UP, Arrow.LEFT }},
        {TileArrow.DOWN, new List<Arrow> { Arrow.DOWN }},
        {TileArrow.DOWN_RIGHT, new List<Arrow> { Arrow.DOWN, Arrow.RIGHT }},
        {TileArrow.DOWN_LEFT, new List<Arrow> { Arrow.DOWN, Arrow.LEFT }},
        {TileArrow.RIGHT, new List<Arrow> { Arrow.RIGHT }},
        {TileArrow.LEFT, new List<Arrow> { Arrow.LEFT }},
    };

    public static readonly Dictionary<TileColor, List<Arrow>> colorKeyMap = new Dictionary<TileColor, List<Arrow>> {
        {TileColor.YELLOW, new List<Arrow> {Arrow.UP}},
        {TileColor.GREEN, new List<Arrow> {Arrow.DOWN}},
        {TileColor.RED, new List<Arrow> {Arrow.RIGHT}},
        {TileColor.BLUE, new List<Arrow> {Arrow.LEFT}},
    };

    public static readonly Dictionary<TileColor, Color> colorNameToColorMap = new Dictionary<TileColor, Color> {
        {TileColor.YELLOW, new Color(0.933f, 0.933f, 0.384f)},
        {TileColor.GREEN, new Color(0.658f, 1f, 0.658f)},
        {TileColor.RED, new Color(1f, 0.729f, 0.729f)},
        {TileColor.BLUE, new Color(0.561f, 0.843f, 1f)},
    };

    public static readonly Dictionary<TileColor, Arrow> colorNameToKeyCodeMap = new Dictionary<TileColor, Arrow> {
        {TileColor.YELLOW, Arrow.UP},
        {TileColor.GREEN, Arrow.DOWN},
        {TileColor.RED, Arrow.RIGHT},
        {TileColor.BLUE, Arrow.LEFT},
    };

    private static readonly TileArrow[] tileArrows = new TileArrow[] {
        TileArrow.UP,
        TileArrow.UP_RIGHT,
        TileArrow.UP_LEFT,
        TileArrow.DOWN,
        TileArrow.DOWN_RIGHT,
        TileArrow.DOWN_LEFT,
        TileArrow.RIGHT,
        TileArrow.LEFT
    };

    public static TileArrow GetRandomTileArrow() {
        return tileArrows[Random.Range(0, tileArrows.Length)];
    }

    private static readonly TileColor[] tileColors = new TileColor[] {
        TileColor.YELLOW,
        TileColor.GREEN,
        TileColor.RED,
        TileColor.BLUE
    };

    public static TileColor GetRandomTileColor() {
        return tileColors[Random.Range(0, tileColors.Length)];
    }

    private static readonly Dictionary<Player, Dictionary<Arrow, KeyCode>> playerArrowKeyCodeMapper = new Dictionary<Player, Dictionary<Arrow, KeyCode>> {
        {
            Player.PLAYER_1,
            new Dictionary<Arrow, KeyCode> {
                { Arrow.UP, KeyCode.UpArrow },
                { Arrow.DOWN, KeyCode.DownArrow },
                { Arrow.RIGHT, KeyCode.RightArrow },
                { Arrow.LEFT, KeyCode.LeftArrow }
            }
        },
        {
            Player.PLAYER_2,
            new Dictionary<Arrow, KeyCode> {
                { Arrow.UP, KeyCode.W },
                { Arrow.DOWN, KeyCode.S },
                { Arrow.RIGHT, KeyCode.D },
                { Arrow.LEFT, KeyCode.A }
            }
        }
    };

    public static KeyCode GetKeyCodeForPlayer(Player player, Arrow arrow) {
        return playerArrowKeyCodeMapper[player][arrow];
    }
}