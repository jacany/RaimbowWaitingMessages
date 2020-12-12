using Exiled.API.Features;
using MEC;
using System.Collections.Generic;

namespace RaimbowWaitingMessages
{
    public class RaimbowWaitingMessages : Plugin<Config>
    {
        public override string Name { get; } = "RaimbowWaitingScreen";
        public override string Author { get; } = "JesusQC";
        public override string Prefix { get; } = "RaimbowWaitingScreen";

        int i = 0;
        string[] colors = { "#f54242", "#f56042", "#f57e42", "#f59c42", "#f5b942", "#f5d742", "#f5f542", "#d7f542", "#b9f542", "#9cf542", "#7ef542", "#60f542", "#42f542", "#42f560", "#42f57b", "#42f599", "#42f5b6", "#42f5d4", "#42f5f2", "#42ddf5", "#42bcf5", "#429ef5", "#4281f5", "#4263f5", "#4245f5", "#5a42f5", "#7842f5", "#9642f5", "#b342f5", "#d142f5", "#ef42f5", "#f542dd", "#f542c2", "#f542aa", "#f5428d", "#f5426f", "#f54251" };
        private static List<CoroutineHandle> coroutines = new List<CoroutineHandle>();

        public override void OnEnabled()
        {
            base.OnEnabled();

            Exiled.Events.Handlers.Server.WaitingForPlayers += OnWaiting;
        }
        public override void OnDisabled()
        {
            base.OnDisabled();

            Exiled.Events.Handlers.Server.WaitingForPlayers -= OnWaiting;
        }

        public void OnWaiting()
        {
            coroutines.Add(Timing.RunCoroutine(RaimbowHint()));
        }

        public void OnRestarting()
        {
            foreach (CoroutineHandle coroutine in coroutines)
                Timing.KillCoroutines(coroutine);
        }

        IEnumerator<float> RaimbowHint()
        {
            for (; ; )
            {
                if (Round.IsStarted) yield break;
                Map.ShowHint(Config.WaitingTextText.Replace("%raimbow%", colors[i++ % colors.Length]), 2);
                yield return Timing.WaitForSeconds(0.5f);
            }
        }
    }
}
