namespace Roguelike {

    using System.Diagnostics;
    
    class EndScreen : IKeyController {
        public void onKeyPressed(ConsoleKeyInfo charKey) {
            if (charKey.Key == ConsoleKey.Escape) {
                Process.GetCurrentProcess().Kill();
            } else if (charKey.Key == ConsoleKey.R) {
                App.restartGame();
            }
        }
    }
}