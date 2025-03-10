using System;

namespace Scenes.Oyun2.Scripts
{
    public static class Oyun2_GeneralEvents
    {
        #region GeneralEvent

        public static Action OnGameStarted;
        public static Action OnGameEnded;
        
        public static Action OnWrongeChoise;

        #endregion
        
        #region ScoreEvents
        
        public static Action<int> OnScoreChanged;
        
        #endregion
    }
}
