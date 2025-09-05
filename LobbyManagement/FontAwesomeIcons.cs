namespace LobbyManagement
{
    static class FontAwesomeIcons
    {
        public static readonly string ArrowsRotate = FromCodePoint(0xF021);
        public static readonly string Burst = FromCodePoint(0xE4DC);
        public static readonly string Car = FromCodePoint(0xF1B9);
        public static readonly string CarBurst = FromCodePoint(0xF5E1);
        public static readonly string CircleExclamation = FromCodePoint(0xF06A);
        public static readonly string CircleQuestion = FromCodePoint(0xF059);
        public static readonly string Cross = FromCodePoint(0xF00D);
        public static readonly string Download = FromCodePoint(0xF019);
        public static readonly string FlagCheckered = FromCodePoint(0xF11E);
        public static readonly string HourglassHalf = FromCodePoint(0xF252);
        public static readonly string Stopwatch = FromCodePoint(0xF2F2);
        public static readonly string User = FromCodePoint(0xF007);

        private static string FromCodePoint(int code) => new((char)code, 1);
    }
}