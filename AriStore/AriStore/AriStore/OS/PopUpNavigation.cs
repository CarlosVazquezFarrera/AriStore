namespace AriStore.OS
{
    using AriStore.Enumeration;
    using AriStore.PopUps;
    using AriStore.ViewModels.PopUps;
    using Rg.Plugins.Popup.Pages;
    using Rg.Plugins.Popup.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class PopUpNavigation
    {
        public static async Task PushModalAsync(PopUpKeys popUpKey, params object[] parameters)
        {
            switch (popUpKey)
            {
                case PopUpKeys.Mensaje:
                    PopUpViewModel.GetInstance().Mensaje = (string)parameters[0];
                    await IsPopUpInstanced(new MnesajePopUp());
                    break;
            }

        }
        private static async Task IsPopUpInstanced(PopupPage NuevoPopUp)
        {
            short PopUpSimilaresApilados = 0;
            if (PopupNavigation.Instance.PopupStack != null && PopupNavigation.Instance.PopupStack.Count > 0)
            {
                List<PopupPage> ListaDePopUps = PopupNavigation.Instance.PopupStack.ToList();
                PopUpSimilaresApilados = (short)ListaDePopUps.Where(p => p.GetType() == NuevoPopUp.GetType()).Count();
            }
            if (PopUpSimilaresApilados < 1)
                await PopupNavigation.Instance.PushAsync(NuevoPopUp, true);
        }
    }
}
