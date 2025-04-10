using System;

namespace Scenes.Oyun2.Scripts
{
    public static class Oyun2_GeneralEvents
    {
        #region GeneralEvent

        public static Action OnGameStarted;
        public static Action OnGameFinish;
        
        public static Action OnGameOver;

        #endregion
        
        #region ScoreEvents
        
        public static Action<int> OnScoreChanged;
        
        #endregion
    }
}
