namespace EasyMacros.Macros
{
    /// <summary>
    /// Describes a macro type
    /// </summary>
    public enum MacroType
    {
        /// <summary>
        /// Keyboard macro. Launched by pressing keyboard keys.
        /// </summary>
        Keyboard,

        /// <summary>
        /// Mouse macro. Launched by pressing mouse buttons.
        /// </summary>
        Mouse,

        /// <summary>
        /// Window Open macro. Launched when a window opens.
        /// </summary>
        WinOpen,

        /// <summary>
        /// Startup macro. Launched when this app is launched.
        /// </summary>
        Startup,

        /// <summary>
        /// IDLE macro. Launched after no mouse/keyboard input for a certain amount of time.
        /// </summary>
        IDLE,

        /// <summary>
        /// Rewrite Keyboard macro. Launched by pressing keyboard keys, and suppress triggering keypresses.
        /// </summary>
        RewriteKeyboard
    };
}
