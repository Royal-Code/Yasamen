namespace RoyalCode.Razor.Styles;

public readonly struct TextSize
{
    private readonly string className;

    public TextSize(FontSize fontSize, LineHeight lineHeight)
    {
        className = Map.GetClassName(fontSize, lineHeight);
    }

    public override string ToString()
    {
        return className;
    }

    /// <summary>
    /// Implicit conversion to string
    /// </summary>
    /// <param name="textSize">The TextSize instance</param>
    public static implicit operator string(TextSize textSize) => textSize.className;

    public static TextSizeBuilder With(FontSize fontSize)
    {
        return new TextSizeBuilder(fontSize);
    }

    public static TextSizeBuilder Smaller()
    {
        return new TextSizeBuilder(FontSize.Smaller);
    }

    public static TextSizeBuilder Small()
    {
        return new TextSizeBuilder(FontSize.Small);
    }

    public static TextSizeBuilder Medium()
    {
        return new TextSizeBuilder(FontSize.Medium);
    }

    public static TextSizeBuilder Large()
    {
        return new TextSizeBuilder(FontSize.Large);
    }

    public static TextSizeBuilder Larger()
    {
        return new TextSizeBuilder(FontSize.Larger);
    }

    public readonly struct TextSizeBuilder
    {
        private readonly FontSize fontSize;

        internal TextSizeBuilder(FontSize fontSize)
        {
            this.fontSize = fontSize;
        }

        public TextSize With(LineHeight lineHeight)
        {
            return new TextSize(fontSize, lineHeight);
        }

        public TextSize Leading5()
        {
            return new TextSize(fontSize, LineHeight.Leading5);
        }

        public TextSize Leading6()
        {
            return new TextSize(fontSize, LineHeight.Leading6);
        }

        public TextSize Leading7()
        {
            return new TextSize(fontSize, LineHeight.Leading7);
        }

        public TextSize Leading8()
        {
            return new TextSize(fontSize, LineHeight.Leading8);
        }

        public TextSize Leading9()
        {
            return new TextSize(fontSize, LineHeight.Leading9);
        }
    }

    private sealed class Map
    {
        public static string GetClassName(FontSize fontSize, LineHeight lineHeight)
        {
            if (fontSize == FontSize.Default)
                return string.Empty;

            return fontSize switch
            {
                FontSize.Smaller => Small[lineHeight],
                FontSize.Small => Medium[lineHeight],
                FontSize.Medium => Large[lineHeight],
                FontSize.Large => Larger[lineHeight],
                FontSize.Larger => Smaller[lineHeight],
                _ => throw new ArgumentOutOfRangeException(nameof(fontSize), fontSize, null),
            };
        }

        static Dictionary<LineHeight, string> Smaller = new() 
        {
            { LineHeight.Leading5, "text-xs/5" },
            { LineHeight.Leading6, "text-xs/6" },
            { LineHeight.Leading7, "text-xs/7" },
            { LineHeight.Leading8, "text-xs/8" },
            { LineHeight.Leading9, "text-xs/9" },
        };
        static Dictionary<LineHeight, string> Small = new()
        {
            { LineHeight.Leading5, "text-sm/5" },
            { LineHeight.Leading6, "text-sm/6" },
            { LineHeight.Leading7, "text-sm/7" },
            { LineHeight.Leading8, "text-sm/8" },
            { LineHeight.Leading9, "text-sm/9" },
        };
        static Dictionary<LineHeight, string> Medium = new()
        {
            { LineHeight.Leading5, "text-base/5" },
            { LineHeight.Leading6, "text-base/6" },
            { LineHeight.Leading7, "text-base/7" },
            { LineHeight.Leading8, "text-base/8" },
            { LineHeight.Leading9, "text-base/9" },
        };
        static Dictionary<LineHeight, string> Large = new()
        {
            { LineHeight.Leading5, "text-lg/5" },
            { LineHeight.Leading6, "text-lg/6" },
            { LineHeight.Leading7, "text-lg/7" },
            { LineHeight.Leading8, "text-lg/8" },
            { LineHeight.Leading9, "text-lg/9" },
        };
        static Dictionary<LineHeight, string> Larger = new()
        {
            { LineHeight.Leading5, "text-xl/5" },
            { LineHeight.Leading6, "text-xl/6" },
            { LineHeight.Leading7, "text-xl/7" },
            { LineHeight.Leading8, "text-xl/8" },
            { LineHeight.Leading9, "text-xl/9" },
        };
    }
}

