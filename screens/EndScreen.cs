namespace Roguelike {
    
    class EndScreen : IKeyController {

        public GameStatus state;

        public EndScreen(GameStatus state) {
            this.state = state;
        }

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            if () {
                state = GameStatus.Win;
            } else if () {
                state = GameStatus.Lose;
            }
        }
    }
}