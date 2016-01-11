namespace SIM800HSamples
{
    using Eclo.NETMF.SIM800H;

    static class SamplesExtensions
    {
        internal static string GetDescription(this NetworkRegistrationState value, string network)
        {
            switch (value)
            {
                case NetworkRegistrationState.Error:
                    return "### " + network + " network registration ERROR ###";

                case NetworkRegistrationState.NotSearching:
                    return "### not searching for " + network + " network ###";

                case NetworkRegistrationState.Registered:
                    return "!!! registered with " + network + " network !!!";

                case NetworkRegistrationState.RegistrationDenied:
                    return "### " + network + " network registration DENIED ###";

                case NetworkRegistrationState.Roaming:
                    return "!!! registered with " + network + " network (roaming) !!!";

                case NetworkRegistrationState.Searching:
                    return "... searching " + network + " network ...";

                case NetworkRegistrationState.Unknown:
                default:
                    return "";
            }
        }
    }
}