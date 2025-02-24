using System;

namespace Scenes.Oyun2.Scripts
{
    public static class Oyun2GeneralEvents
    {
        #region GeneralEvent

        public static Action OnGameStarted;
        public static Action OnGameEnded;

        #endregion
        
        #region Player Events

        public static Action OnToRight;
        public static Action OnToLeft;

        #endregion

    }
}
