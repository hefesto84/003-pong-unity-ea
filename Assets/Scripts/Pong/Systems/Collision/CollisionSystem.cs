using Pong.Systems.Ball;
using Pong.Systems.Paddle.Base;

namespace Pong.Systems.Collision
{
    public class CollisionSystem
    {
        private readonly BallSystem _ballSystem;
        private readonly PaddleSystem _playerPaddleSystem;
        private readonly PaddleSystem _opponentPaddleSystem;
        
        public CollisionSystem(BallSystem ballSystem, PaddleSystem playerPaddleSystem, PaddleSystem opponentPaddleSystem)
        {
            _ballSystem = ballSystem;
            _playerPaddleSystem = playerPaddleSystem;
            _opponentPaddleSystem = opponentPaddleSystem;
        }

        public void Update()
        {
            if (_ballSystem.View.Bounds.Intersects(_playerPaddleSystem.View.Bounds))
            {
                _ballSystem.IsCollided(_playerPaddleSystem.PlayerType);
            }
            else if (_ballSystem.View.Bounds.Intersects(_opponentPaddleSystem.View.Bounds))
            {
                _ballSystem.IsCollided(_opponentPaddleSystem.PlayerType);
            }
        }
    }
}